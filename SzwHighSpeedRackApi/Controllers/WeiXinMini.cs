﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Senparc.Weixin;
using Senparc.Weixin.CommonAPIs;
using Senparc.Weixin.Entities;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.WxOpen;
using Senparc.Weixin.WxOpen.AdvancedAPIs.WxApp.UrlLinkJson;
using System;
using System.Threading.Tasks;
using Zhulong.Library.Common;

namespace SzwHighSpeedRackApi.Controllers
{
    [AllowAnonymous]
    public class WeiXinMini : RackBaseApiController
    {
        public static readonly string WxOpenAppId = Config.SenparcWeixinSetting.WxOpenAppId;//与微信小程序后台的AppId设置保持一致，区分大小写。
        public static readonly string WxOpenAppSecret = Config.SenparcWeixinSetting.WxOpenAppSecret;//与微信小程序账号后台的AppId设置保持一致，区分大小写。
        public WeiXinMini()
        {
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<GenerateResultJson> Get(int id)
        {
            //await AccessTokenContainer.RegisterAsync(WxOpenAppId, WxOpenAppSecret);
            //var accessToken = await AccessTokenContainer
            //   .GetAccessTokenAsync("wxd6f7be310d0d9dce").ConfigureAwait(false);
            var result = await Generate(accessTokenOrAppId: WxOpenAppId, expireType: 0, expireTime: DateTime.Now.AddDays(30).TimeSpanMilliseconds());
            return result;
        }


        /// <summary>
        /// 获取小程序 URL Link，适用于短信、邮件、网页、微信内等拉起小程序的业务场景。通过该接口，可以选择生成到期失效和永久有效的小程序链接，有数量限制，目前仅针对国内非个人主体的小程序开放，详见<see href="https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/url-link.html">获取 URL Link</see>
        /// </summary>
        /// <param name="accessTokenOrAppId">接口调用凭证</param>
        /// <param name="path">通过 URL Link 进入的小程序页面路径，必须是已经发布的小程序存在的页面，不可携带 query 。path 为空时会跳转小程序主页</param>
        /// <param name="query">通过 URL Link 进入小程序时的query，最大1024个字符，只支持数字，大小写英文以及部分特殊字符：!#$&'()*+,/:;=?@-._~%</param>
        /// <param name="envVersion">要打开的小程序版本。正式版为 "release"，体验版为"trial"，开发版为"develop"，仅在微信外打开时生效。体验版和开发版仅在iOS上支持，Android将在近期支持。</param>
        /// <param name="isExpire">生成的 URL Link 类型，到期失效：true，永久有效：false。注意，永久有效 Link 和有效时间超过180天的到期失效 Link 的总数上限为10万个，详见<see href="https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/url-link.html">获取 URL Link</see>，生成 Link 前请仔细确认。</param>
        /// <param name="expireType">小程序 URL Link 失效类型，失效时间：0，失效间隔天数：1</param>
        /// <param name="expireTime">到期失效的 URL Link 的失效时间，为 Unix 时间戳。生成的到期失效 URL Link 在该时间前有效。最长有效期为1年。expire_type 为 0 必填</param>
        /// <param name="expireInterval">到期失效的URL Link的失效间隔天数。生成的到期失效URL Link在该间隔时间到达前有效。最长间隔天数为365天。expire_type 为 1 必填</param>
        /// <param name="cloudBase">云开发静态网站自定义 H5 配置参数，可配置中转的云开发 H5 页面。不填默认用官方 H5 页面</param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        public static async Task<GenerateResultJson> Generate(string accessTokenOrAppId, string path = null, string query = null, string envVersion = "release", int? expireType = null, long? expireTime = null, int? expireInterval = null, Generate_CloudBase cloudBase = null, int timeOut = Config.TIME_OUT)
        {
            //string urlFormat = Config.ApiMpHost + "/wxa/generate_urllink?access_token={0}";
            //var result = AccessTokenContainer.TryGetAccessToken(WxOpenAppId, WxOpenAppSecret);
            //var postBody = new
            //{
            //    env_version = envVersion,
            //    expire_type = expireType,
            //    expire_time = expireTime,
            //};
            //return CommonJsonSend.Send<GenerateResultJson>(result, urlFormat, postBody, timeOut: timeOut);

            return await WxOpenApiHandlerWapper.TryCommonApiAsync(async accessToken =>
            {
                string urlFormat = Config.ApiMpHost + "/wxa/generate_urllink?access_token={0}";
                var postBody = new
                {
                    path,
                    query,
                    env_version = envVersion,
                    expire_type = expireType,
                    expire_time = expireTime,
                    expire_interval = expireInterval,
                    cloud_base = cloudBase
                };
                return await CommonJsonSend.SendAsync<GenerateResultJson>(accessToken, urlFormat, postBody, timeOut: timeOut);
            }, accessTokenOrAppId);
        }
    }
}
