using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.Service;

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
        public MessageModel<MngAdmin> Get(int id)
        {
            MngAdmin model = MngAdminService.FindSingle(f => f.Id == id);
            bool flag = model != null || model.Id > 0;
            return new MessageModel<MngAdmin>
            {
                success = flag,
                msg = flag ? "查询成功" : $"没有id为{id}的数据",
                model = flag ? model : new MngAdmin()
            };
        }

        [HttpPost]
        public MessageModel<string> Post([FromBody] MngAdmin model)
        {
            MngAdminService.AddEntity(model);
            return new MessageModel<string>
            {
                success = true,
                msg = "添加成功"
            };
        }

        [HttpDelete("{id}")]
        public MessageModel<string> Delete(int id)
        {
            MngAdminService.DeleteByExp(f => f.Id == id);
            return new MessageModel<string>
            {
                success = true,
                msg = "删除成功"
            };
        }

        [HttpPatch()]
        public MessageModel<PageModel<MngAdmin>> HttpPatch(int pageIndex = 1, int pageSize = 10)
        {
            MessageModel<PageModel<MngAdmin>> messageModel = new MessageModel<PageModel<MngAdmin>>();
            Expression<Func<MngAdmin, bool>> exp = null;
            messageModel.model = MngAdminService.Page<int>(pageIndex, pageSize, p => p.Id, exp, true);
            messageModel.success = true;
            messageModel.msg = "查询成功";
            return messageModel;
        }
    }
}