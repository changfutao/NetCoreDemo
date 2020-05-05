﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CFT.NetCore.WebAppDemo.Entities;
using CFT.NetCore.WebAppDemo.Filters;
using CFT.NetCore.WebAppDemo.Helpers;
using CFT.NetCore.WebAppDemo.Models;
using CFT.NetCore.WebAppDemo.Repository;
using CFT.NetCore.WebAppDemo.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CFT.NetCore.WebAppDemo.Controllers
{
    [Route("api/author")]
    public class AuthorController : ControllerBase
    {
        public IMapper Mapper { get; }
        public IRepositoryWrapper RepositoryWrapper { get; }
        public AuthorController(
            IRepositoryWrapper repositoryWrapper,
            IMapper mapper
            )
        {
            Mapper = mapper;
            RepositoryWrapper = repositoryWrapper;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorViewModel>>> GetAuthorsAsync()
        {
            var authors = await RepositoryWrapper.Author.GetAllAsync();
            authors = authors.OrderBy(x => x.Name);

            var authorViewModelList = Mapper.Map<IEnumerable<AuthorViewModel>>(authors);
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
    }
}