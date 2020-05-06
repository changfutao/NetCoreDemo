using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CFT.NetCore.WebAppDemo.Entities;
using CFT.NetCore.WebAppDemo.Entities.Author;
using CFT.NetCore.WebAppDemo.Filters;
using CFT.NetCore.WebAppDemo.Helpers;
using CFT.NetCore.WebAppDemo.Models;
using CFT.NetCore.WebAppDemo.Repository;
using CFT.NetCore.WebAppDemo.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Microsoft.Net.Http.Headers;

namespace CFT.NetCore.WebAppDemo.Controllers
{
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        public IMapper Mapper { get; }
        public IRepositoryWrapper RepositoryWrapper { get; }
        public IHashFactory HashFactory { get; }
        public AuthorController(
            IRepositoryWrapper repositoryWrapper,
            IMapper mapper,
            IHashFactory hashFactory
            )
        {
            Mapper = mapper;
            RepositoryWrapper = repositoryWrapper;
            HashFactory = hashFactory;
        }
        /// <summary>
        /// 创建资源
        /// </summary>
        /// <param name="authorDto"></param>
        /// <returns></returns>
        [ModelValidation]
        [Route("CreateAuthorAsync")]
        [HttpPost]
        public async Task<ActionResult> CreateAuthorAsync(AuthorDto authorDto)
        {
            ResultModel resultModel = new ResultModel();
            resultModel.Status = 200;
            #region 模型验证
            //验证数据注解是否成功
            //if(!ModelState.IsValid)
            //{
            //    resultModel.ErrorMessages = new List<ErrorMessage>();
            //    foreach (var key in ModelState.Keys)
            //    {
            //        var state = ModelState[key];
            //        if (state.ValidationState.ToString().ToLower() != "valid")
            //        {
            //            resultModel.Status = 500;
            //            foreach (var error in state.Errors)
            //            {
            //                ErrorMessage errorMessage = new ErrorMessage();
            //                errorMessage.ErrorName = key;
            //                errorMessage.ErrorInfo = error.ErrorMessage;
            //                resultModel.ErrorMessages.Add(errorMessage);
            //            }
            //        }
            //    }
            //    return new JsonResult(resultModel);
            //} 
            #endregion
            var author = Mapper.Map<Author>(authorDto);

            RepositoryWrapper.Author.Create(author);
            var result = await RepositoryWrapper.Author.SaveAsync();

            if (!result)
            {
                throw new Exception("创建资源author失败");
            }

            return new JsonResult(resultModel);
        }

        /// <summary>
        /// 获取所有作者信息
        /// </summary>
        /// <returns></returns>
        [Route("GetAuthorsAsync")]
        //Http缓存 Duration绝对过期时间
        //[ResponseCache(Duration =60,Location =ResponseCacheLocation.Any)]
        [ResponseCache(CacheProfileName = "Default")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorViewModel>>> GetAuthorsAsync()
        {
            var authors = await RepositoryWrapper.Author.GetAllAsync();
            authors = authors.OrderBy(x => x.Name);
            var entityHash = HashFactory.GetHash(authors);
            Response.Headers[HeaderNames.ETag] = entityHash;
            if (Response.Headers.TryGetValue(HeaderNames.IfModifiedSince, out var requestETag) && entityHash == requestETag)
            {
                return StatusCode(StatusCodes.Status304NotModified);
            }
            var authorViewModelList = Mapper.Map<IEnumerable<AuthorViewModel>>(authors);
            Thread.Sleep(5000);
            return authorViewModelList.ToList();
        }

        /// <summary>
        /// 根据Id获取作者
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        [Route("GetAuthorAsync")]
        [HttpGet]
        public async Task<ActionResult<AuthorViewModel>> GetAuthorAsync(Guid authorId)
        {
            var author = await RepositoryWrapper.Author.GetByIdAsync(authorId);
            if (author == null)
            {
                return new JsonResult(new { status = 404 });
            }

            var authorViewModel = Mapper.Map<AuthorViewModel>(author);
            return authorViewModel;
        }

        /// <summary>
        /// 获取作者分页数据 
        /// </summary>
        /// <returns></returns>
        [Route("GetAuthorPage")]
        [HttpGet]
        public async Task<PagedList<AuthorViewModel>> GetAuthorPage([FromQuery]AuthorResourceParameters parameters)
        {
            var authors = await RepositoryWrapper.Author.GetAllAsync();
            if(!string.IsNullOrEmpty(parameters.BirthPlace))
            {
                authors = authors.Where(x => x.BirthPlace == parameters.BirthPlace).AsEnumerable();
            }

            int totalCount = authors.Count();
            var authorsPage = authors.AsQueryable().OrderBy(parameters.SortBy).Skip((parameters.PageNumber - 1) * parameters.PageSize)
                    .Take(parameters.PageSize);
            var authorViewModels = Mapper.Map<IEnumerable<AuthorViewModel>>(authorsPage);
            return new PagedList<AuthorViewModel>(authorViewModels.ToList(), totalCount, parameters.PageNumber, parameters.PageSize);
        }
    }
}