﻿/*
********************************************************************
*
*    曹旭升（sheng.c）
*    E-mail: cao.silhouette@msn.com
*    QQ: 279060597
*    https://github.com/iccb1013
*    http://shengxunwei.com
*
*    © Copyright 2016
*
********************************************************************/


using Sheng.WeixinConstruction.Client.Core;
using Sheng.WeixinConstruction.Core;
using Sheng.WeixinConstruction.Infrastructure;
using Sheng.WeixinConstruction.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sheng.WeixinConstruction.Client.Shell.Areas.Api.Controllers
{
    public class AdvancedArticleController : ApiBasalController
    {
        private static readonly AdvancedArticleManager _advancedArticleManager = AdvancedArticleManager.Instance;

        [AllowedOnlyOpenId]
        public ActionResult ShareTimeline()
        {
            string strPageId = Request.QueryString["pageId"];
            Guid pageId = Guid.Empty;
            if (String.IsNullOrEmpty(strPageId) || Guid.TryParse(strPageId, out pageId) == false)
            {
                return RespondResult(false, "参数无效。");
            }

            ShareResult result;
            if (MemberContext == null)
            {
                result = _advancedArticleManager.ShareTimeline(pageId, null, this.OpenId);
            }
            else
            {
                result = _advancedArticleManager.ShareTimeline(pageId, MemberContext.Member.Id, this.OpenId);
            }

            return RespondDataResult(result);
        }

        [AllowedOnlyOpenId]
        public ActionResult ShareAppMessage()
        {
            string strPageId = Request.QueryString["pageId"];
            Guid pageId = Guid.Empty;
            if (String.IsNullOrEmpty(strPageId) || Guid.TryParse(strPageId, out pageId) == false)
            {
                return RespondResult(false, "参数无效。");
            }

            ShareResult result;
            if (MemberContext == null)
            {
                result = _advancedArticleManager.ShareAppMessage(pageId, null, this.OpenId);
            }
            else
            {
                result = _advancedArticleManager.ShareAppMessage(pageId, MemberContext.Member.Id, this.OpenId);
            }

            return RespondDataResult(result);
        }
    }
}