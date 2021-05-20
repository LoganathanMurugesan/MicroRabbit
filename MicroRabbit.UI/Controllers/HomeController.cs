using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroRabbit.UI.Views;
using MicroRabbit.UI.Models.DTO;
using MicroRabbit.UI.Services;

namespace MicroRabbit.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransferService _transferService;

        public HomeController(ITransferService transferService)
        {
            _transferService = transferService;
        }


        [HttpGet]
        public ActionResult Index() 
        {
            return View("Index");
        }
        

        [HttpPost]
        public async Task<ActionResult> Transfer(TransferViewModel transferViewModel)
        {
            TransferDTO transferDTO = new TransferDTO()
            {
                FromAccount = transferViewModel.FromAccount,
                ToAccount = transferViewModel.ToAccount,
                TransferAmount = transferViewModel.TransferAmount
            };

           await _transferService.Transfer(transferDTO);

            return View("Index");
        }

    }
}
