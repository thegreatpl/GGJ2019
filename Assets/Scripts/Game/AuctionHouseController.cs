using Assets.Scripts.Game.Objects;
using Assets.Scripts.StarSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class AuctionHouseController : MonoBehaviour
{
    /// <summary>
    /// How much to claim and auction on object. 
    /// </summary>
    public float AuctionCost = 1000;

    /// <summary>
    /// How much the atmosphere rating is multiplied by. 
    /// </summary>
    public float AtmosphereRatingMultiplier = 5.5f;

    public int MaxAtmosphereRating = 10;

    public int MaxResourcerating = 100; 

    public Player Player;

    public Dictionary<string, Companies> Companies = new Dictionary<string, Companies>();

    /// <summary>
    /// The resource manager. 
    /// </summary>
    public StarsystemGenerator StarsystemGenerator; 

    // Start is called before the first frame update
    void Start()
    {
        Player = GameController.Game.Player; 
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var comp in Companies)
            comp.Value.LastWon++;
    }


    public IEnumerator GenerateCompanies()
    {
        Companies = new Dictionary<string, Companies>(); 
        for (int idx = 0; idx < Random.Range(10, 100); idx++)
        {
            int maxcooldown = Random.Range(100, 10000);
            var company = new Companies()
            {
                MinTimeToDevelop = maxcooldown,
                LastWon = maxcooldown,
                Name = $"Company{idx}",
                SizeModifier = Random.Range(0.1f, 10),
                AtmosphereRating = new Dictionary<string, Rating>(),
                ResourceRatings = new Dictionary<string, Rating>()
            };
            for(int idx2 = 0; idx2 < Random.Range(1, StarsystemGenerator.Atmospheres.Count); idx2++)
            {
                var atmosphere = StarsystemGenerator.Atmospheres.RandomElement();
                int rating = Random.Range(1, MaxAtmosphereRating);

                Rating rate;
                if (company.AtmosphereRating.ContainsKey(atmosphere))
                    rate = company.AtmosphereRating[atmosphere];
                else
                {
                    rate = new Rating() { Name = atmosphere, Price = 0 };
                    company.AtmosphereRating.Add(rate.Name, rate); 
                }

                rate.Price += rating * AtmosphereRatingMultiplier; 
            }
            for (int idx2 = 0; idx2 < Random.Range(1, 20); idx2++)
            {
                var resource = StarsystemGenerator.ResourceMananger.ResourceDefinitions.RandomElement().Value;
                int rating = Random.Range(1, MaxResourcerating);

                Rating rate;
                if (company.ResourceRatings.ContainsKey(resource.Name))
                    rate = company.ResourceRatings[resource.Name];
                else
                {
                    rate = new Rating() { Name = resource.Name, Price = 0 };
                    company.ResourceRatings.Add(rate.Name, rate);
                }

                rate.Price += rating * resource.ValuePerInstance;
            }

            Companies.Add(company.Name, company); 

            yield return null; 
        }
    }

    /// <summary>
    /// Start an auction. 
    /// </summary>
    /// <param name="obj"></param>
    public void AuctionObject(SurveyObject obj)
    {
        if (!string.IsNullOrWhiteSpace(obj.Owner))
            return;

        Player.Money -= AuctionCost;
        obj.Owner = "Auction"; 
        StartCoroutine(Auction(obj)); 

    }

    IEnumerator Auction(SurveyObject obj)
    {
        float currentPrice = 100;

        List<CompanyMaxBid> maxBids = new List<CompanyMaxBid>(); 
        foreach(var comp in Companies.Values)
        {
            maxBids.Add(new CompanyMaxBid() { name = comp.Name, maxPrice = comp.CalculateMaxCompanyPrice(obj) }); 
        }

        maxBids = maxBids.Where(x => x.maxPrice > currentPrice).ToList();

        //no one wanted it; bid fails. 
        if (maxBids.Count < 1)
        {
            //fail the auction. 
            obj.Owner = ""; 
            yield break;
        }
        CompanyMaxBid currentWinner; 
        do
        {
            currentWinner = maxBids[0];

            currentPrice += 100;


            maxBids = maxBids.Where(x => x.maxPrice > currentPrice).ToList();

            yield return null; 

        } while (maxBids.Count > 1); 

        yield return null;

        obj.Owner = currentWinner.name;
        Companies[currentWinner.name].LastWon = 0; 
        Player.Money += currentPrice; 
    }

    class CompanyMaxBid
    {
        public string name;

        public float maxPrice; 
    }
}
