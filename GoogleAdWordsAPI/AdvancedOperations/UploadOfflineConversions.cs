using Google.Api.Ads.AdWords.Lib;
using Google.Api.Ads.AdWords.v201509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAdWordsAPI.AdvancedOperations
{
    public class UploadOfflineConversions : AdWordsBase
    {
        public UploadOfflineConversions(string clientCustomerId, string userAgent, string developerToken, string oAuth2ClientId, string oAuth2ClientSecret, string oAuth2RefreshToken, string oAuth2Mode)
            : base(clientCustomerId, userAgent, developerToken, oAuth2ClientId, oAuth2ClientSecret, oAuth2RefreshToken, oAuth2Mode) { }

        public OfflineConversionFeedReturnValue UploadOfflineConversionsToExistingConversionType(AdWordsUser user, List<OfflineConversionFeed> offlineConversions)
        {
            try
            {
                // Get the OfflineConversionFeedService.
                OfflineConversionFeedService offlineConversionFeedService =
                    (OfflineConversionFeedService)user.GetService(
                        AdWordsService.v201509.OfflineConversionFeedService);

                List<OfflineConversionFeedOperation> offlineConversionOperations = new List<OfflineConversionFeedOperation>();

                foreach (OfflineConversionFeed conversion in offlineConversions)
                {
                    OfflineConversionFeedOperation offlineConversionOperation =
                    new OfflineConversionFeedOperation();

                    offlineConversionOperation.@operator = Operator.ADD;
                    offlineConversionOperation.operand = conversion;

                    offlineConversionOperations.Add(offlineConversionOperation);
                }

                OfflineConversionFeedReturnValue offlineConversionRetval =
                    offlineConversionFeedService.mutate(offlineConversionOperations.ToArray());

                return offlineConversionRetval;
            }
            catch (Exception e)
            {
                throw new System.ApplicationException("Failed upload offline conversions.", e);
            }
        }
    }
}
