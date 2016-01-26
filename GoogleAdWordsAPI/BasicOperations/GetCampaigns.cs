using Google.Api.Ads.AdWords.Lib;
using Google.Api.Ads.AdWords.v201509;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoogleAdWordsAPI.BasicOperations
{
    public class GetCampaigns : AdWordsBase
    {
        public GetCampaigns(string clientCustomerId, string userAgent, string developerToken, string oAuth2ClientId, string oAuth2ClientSecret, string oAuth2RefreshToken)
            : base(clientCustomerId, userAgent, developerToken, oAuth2ClientId, oAuth2ClientSecret, oAuth2RefreshToken) { }

        public List<Campaign> GetAllCampaigns()
        {
            List<Campaign> campaigns = new List<Campaign>();

            // Get the CampaignService.
            CampaignService campaignService =
                (CampaignService)User.GetService(AdWordsService.v201509.CampaignService);

            // Create the selector.
            Selector selector = new Selector()
            {
                fields = new string[] { Campaign.Fields.Id, Campaign.Fields.Name, Campaign.Fields.Status },
                paging = Paging.Default
            };

            CampaignPage page = new CampaignPage();

            try
            {
                do
                {
                    // Get the campaigns.
                    page = campaignService.get(selector);

                    // Display the results.
                    if (page != null && page.entries != null)
                    {
                        int i = selector.paging.startIndex;
                        foreach (Campaign campaign in page.entries)
                        {
                            campaigns.Add(campaign);
                        }
                    }
                    selector.paging.IncreaseOffset();
                } while (selector.paging.startIndex < page.totalNumEntries);

                return campaigns;
            }
            catch (Exception e)
            {
                throw new System.ApplicationException("Failed to retrieve campaigns", e);
            }

        }
    }
}
