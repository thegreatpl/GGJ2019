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

    public Player Player; 

    public List<Companies> Companies;

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
        
    }

    /// <summary>
    /// Start an auction. 
    /// </summary>
    /// <param name="obj"></param>
    public void AuctionObject(SurveyObject obj)
    {
        if (string.IsNullOrWhiteSpace(obj.Owner))
            return;

        Player.Money -= AuctionCost;
        obj.Owner = "Auction"; 
        StartCoroutine(Auction(obj)); 

    }

    IEnumerator Auction(SurveyObject obj)
    {
        float currentPrice = 100;

        List<CompanyMaxBid> maxBids = new List<CompanyMaxBid>(); 
        foreach(var comp in Companies)
        {
            maxBids.Add(new CompanyMaxBid() { name = comp.Name, maxPrice = comp.CalculateMaxCompanyPrice(obj) }); 
        }

        maxBids = maxBids.Where(x => x.maxPrice > currentPrice).ToList();

        //no one wanted it; bid fails. 
        if (maxBids.Count < 1)
            yield break;
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
        Player.Money += currentPrice; 
    }

    class CompanyMaxBid
    {
        public string name;

        public float maxPrice; 
    }
}
