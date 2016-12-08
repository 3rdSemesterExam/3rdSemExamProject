using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dsr_betalling.Common;
using dsr_betalling.Model;

namespace dsr_betalling.Handler
{
    public class PurchaseHandler
    {
        public async Task<bool> MakePurchase(List<PurchaseItem> PurchaseItems, string ChipId, float Discount)
        {
            var result = true;

            // Gather Info
            var totalPrice = PurchaseItems.Sum(purchaseItem => purchaseItem.Amount * purchaseItem.Price) - Discount;
            var Account = AccountHandler.GetAccount(ChipHandler.GetAccountIdFromChipId(ChipId)).Result;
            
            // Post Purchase
            var PurchaseId = int.Parse(await Facade.PostScalarAsync(new Purchase(Account.Id, Authorization.UserId, totalPrice, DateTime.Now)));

            // Post PurchaseItems
            foreach (var purchaseItem in PurchaseItems)
            {
                purchaseItem.FK_Purchase = PurchaseId;
                if (!await Facade.PostAsync(purchaseItem))
                    result = false;
            }

            // Verify Result
            if (!result) return false;

            // Withdraw Funds, Update Account
            Account.WithdrawFunds(totalPrice);
            result = await AccountHandler.UpdateAccount(Account);

            return result;
        }
    }
}
