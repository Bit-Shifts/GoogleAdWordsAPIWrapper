using Google.Api.Ads.AdWords.Lib;
using Google.Api.Ads.Common.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAdWordsAPI
{
    public class AdWordsBase
    {

        #region Private Properties

        protected AdWordsUser User { get; set; }

        #endregion

        public AdWordsBase(string clientCustomerId, string userAgent, string developerToken, string oAuth2ClientId, string oAuth2ClientSecret, string oAuth2RefreshToken)
        {
            User = new AdWordsUser();

            //Settings specific to AdWords API
            ((AdWordsAppConfig)User.Config).ClientCustomerId = clientCustomerId;
            ((AdWordsAppConfig)User.Config).UserAgent = userAgent;
            ((AdWordsAppConfig)User.Config).DeveloperToken = developerToken;

            //OAuth2 configuration
            ((AdWordsAppConfig)User.Config).OAuth2ClientId = oAuth2ClientId;
            ((AdWordsAppConfig)User.Config).OAuth2ClientSecret = oAuth2ClientSecret;
            ((AdWordsAppConfig)User.Config).OAuth2RefreshToken = oAuth2RefreshToken;
            ((AdWordsAppConfig)User.Config).OAuth2Mode = OAuth2Flow.APPLICATION;
        }

    }
}
