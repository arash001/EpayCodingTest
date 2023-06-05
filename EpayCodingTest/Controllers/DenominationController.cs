using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace EpayCodingTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenominationController : ControllerBase
    {
        private RepositoryDbContext _dbContext;

        public DenominationController(RepositoryDbContext repositoryDbContext)
        {
            _dbContext = repositoryDbContext;
        }

        //[HttpGet]
        //public ActionResult CallTest()
        //{
        //    return Ok("you call test api!!!!");
        //}


        //[HttpGet]
        //public ActionResult CalculatePayoutCombinations(int amount)
        //{
        //    var denominations = _dbContext.Denominations.ToList();
        //    var combinations = new List<List<PayoutCombination>>();
        //    CalculatePayoutCombinationsHelper(amount, denominations, new List<PayoutCombination>(), combinations);
        //    return Ok(combinations);
        //}

        //private void CalculatePayoutCombinationsHelper(int amount, List<Denomination> denominations, List<PayoutCombination> currentCombination, List<List<PayoutCombination>> combinations)
        //{
        //    if (amount == 0)
        //    {
        //        combinations.Add(new List<PayoutCombination>(currentCombination));
        //        return;
        //    }

        //    if (denominations.Count == 0 || amount < 0)
        //        return;

        //    var denomination = denominations[0];
        //    denominations.RemoveAt(0);

        //    var maxCount = amount / denomination.Value;

        //    for (int count = 0; count <= maxCount; count++)
        //    {
        //        currentCombination.Add(new PayoutCombination { Id = denomination.Id, PayoutAmount = count });
        //        CalculatePayoutCombinationsHelper(amount - count * denomination.Value, denominations, currentCombination, combinations);
        //        currentCombination.RemoveAt(currentCombination.Count - 1);
        //    }

        //    denominations.Insert(0, denomination);
        //}

        private static readonly int[] DenominationsArr = { 10, 50, 100 };

        //[HttpGet]
        //[Route("api/atm/payouts")]
        //public ActionResult GetPayouts()
        //{
        //    int[] payoutAmounts = { 30, 140 };// { 30, 50, 60, 80, 140, 230, 370, 610, 980 };
        //    Dictionary<int, List<List<int>>> result = new Dictionary<int, List<List<int>>>();

        //    foreach (int amount in payoutAmounts)
        //    {
        //        List<List<int>> combinations = GetCombinations(amount, 0, new List<int>());
        //        result.Add(amount, combinations);
        //    }

        //    return Ok(result);
        //}

        [HttpGet]
        [Route("api/atm/payouts")]
        //public ActionResult GetPayouts(int[] payoutAmounts)
        public ActionResult GetPayouts(int payoutAmounts)
        {
            Dictionary<int, List<List<int>>> result = new Dictionary<int, List<List<int>>>();
          
            //foreach (int amount in payoutAmounts)
            int amount = payoutAmounts;
            {
                List<List<int>> combinations = GetCombinations(amount, 0, new List<int>());
                result.Add(amount, combinations);
            }

            return Ok(result);
        }

        private List<List<int>> GetCombinations(int amount, int index, List<int> currentCombination)
        {
            List<List<int>> combinations = new List<List<int>>();
            var DenominationsList = this._dbContext.Denominations.ToArray();
            if (amount == 0)
            {
                combinations.Add(new List<int>(currentCombination));
                return combinations;
            }

            if (index >= DenominationsList.Length)
            {
                return combinations;
            }

            int currentDenomination =Convert.ToInt32( DenominationsList[index].Value);
            int maxCount = amount / currentDenomination;

            for (int count = maxCount; count >= 0; count--)
            {
                int remainingAmount = amount - (currentDenomination * count);
                currentCombination.Add(count * currentDenomination);

                List<List<int>> subCombinations = GetCombinations(remainingAmount, index + 1, currentCombination);
                combinations.AddRange(subCombinations);

                currentCombination.RemoveAt(currentCombination.Count - 1);
            }

            return combinations;
        }
    }
}
