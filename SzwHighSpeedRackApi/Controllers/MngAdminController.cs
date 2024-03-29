﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.Service;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SzwHighSpeedRackApi.Controllers
{
    [AllowAnonymous]
    public class MngAdminController : RackBaseApiController
    {
        private IBaseService<MngAdmin> MngAdminService;

        public MngAdminController(IBaseService<MngAdmin> MngAdminService)
        {
            this.MngAdminService = MngAdminService;
        }

        [HttpGet("{id}")]
        public async Task<MessageModel<MngAdmin>> Get(int id)
        {
            var model = await MngAdminService.FindListAsync(i => EF.Functions.JsonContains(i.GroupManage, id.ToString(), "$"));
            bool flag = model.FirstOrDefault() != null;
            return new MessageModel<MngAdmin>
            {
                success = flag,
                msg = flag ? "查询成功" : $"没有id为{id}的数据",
                model = flag ? model.FirstOrDefault() : new MngAdmin()
            };
        }

        [HttpPost]
        public async Task<MessageModel<string>> Post([FromBody] MngAdmin model)
        {
           await MngAdminService.AddEntityAsync(model);
            return new MessageModel<string>
            {
                success = true,
                msg = "添加成功"
            };
        }

        [HttpDelete("{id}")]
        public async Task<MessageModel<string>> Delete(int id)
        {
           await MngAdminService.DeleteByExpAsync(f => f.Id == id);
            return new MessageModel<string>
            {
                success = true,
                msg = "删除成功"
            };
        }

        [HttpPatch()]
        public async Task<MessageModel<PageModel<MngAdmin>>> HttpPatch(int pageIndex = 1, int pageSize = 10)
        {
            MessageModel<PageModel<MngAdmin>> messageModel = new MessageModel<PageModel<MngAdmin>>();
            Expression<Func<MngAdmin, bool>> exp = null;
            messageModel.model = await MngAdminService.PageAsync(pageIndex, pageSize, p => p.Id, exp, true);
            messageModel.success = true;
            messageModel.msg = "查询成功";
            return messageModel;
        }
    }
}