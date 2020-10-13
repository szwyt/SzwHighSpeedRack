using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SzwHighSpeedRack.Entity;
using SzwHighSpeedRack.Service;

namespace SzwHighSpeedRackApi.Controllers
{
    [AllowAnonymous]
    public class PdProductController : RackBaseApiController
    {
        private IBaseService<PdProduct> PdProductService;

        public PdProductController(IBaseService<PdProduct> PdProductService)
        {
            this.PdProductService = PdProductService;
        }

        [HttpGet("{id}")]
        public MessageModel<PdProduct> Get(int id)
        {
            PdProduct model = PdProductService.FindSingle(f => f.Id == id);
            bool flag = model == null;
            return new MessageModel<PdProduct>
            {
                success = !flag,
                msg = !flag ? "查询成功" : $"没有id为{id}的数据",
                model = !flag ? model : new PdProduct()
            };
        }

        [HttpPost]
        public MessageModel<string> Post([FromBody] PdProduct model)
        {
            PdProductService.AddEntity(model);
            return new MessageModel<string>
            {
                success = true,
                msg = "添加成功"
            };
        }

        [HttpDelete("{id}")]
        public MessageModel<string> Delete(int id)
        {
            PdProductService.DeleteByExp(f => f.Id == id);
            return new MessageModel<string>
            {
                success = true,
                msg = "删除成功"
            };
        }

        [HttpPatch()]
        public MessageModel<PageModel<PdProduct>> HttpPatch(int pageIndex = 1, int pageSize = 10)
        {
            MessageModel<PageModel<PdProduct>> messageModel = new MessageModel<PageModel<PdProduct>>();
            Expression<Func<PdProduct, bool>> exp = null;
            messageModel.model = PdProductService.Page<int>(pageIndex, pageSize, p => p.Id, exp, true);
            messageModel.success = true;
            messageModel.msg = "查询成功";
            return messageModel;
        }
    }
}