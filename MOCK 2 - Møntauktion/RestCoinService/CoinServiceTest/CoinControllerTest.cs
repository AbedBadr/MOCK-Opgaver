using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestCoinService.Controllers;
using RestCoinService.Model;

namespace CoinServiceTest
{
    [TestClass]
    public class CoinControllerTest
    {
        [TestMethod]
        public void GetAllCoinsTest()
        {
            CoinController controller = new CoinController();

            List<Coin> cList = controller.GetCoins();

            Assert.AreEqual(CoinController.coinList, cList, "Are not equal");
        }

        [TestMethod]
        public void GetOneCoinTest()
        {
            CoinController controller = new CoinController();
            Coin theCoin = CoinController.coinList.Find(c => c.Id == 2);

            Coin coin = controller.GetOneCoin(2);

            Assert.AreEqual(theCoin, coin, "Are not equal");
        }


    }
}
