using Dto.Payment;
using ZarinPal.Class;

namespace Diet.WebMVC.Pages.Regimens;

[Authorize]
public class CheckoutModel : PageModel
{
    private readonly IGenericRepository<Regimen> _repository;
    private readonly ICheckoutService _checkoutService;
    private Payment _payment;
    private Transactions _transactions;
    private Authority _authority;

    public CheckoutModel(IGenericRepository<Regimen> repository, ICheckoutService checkoutService)
    {
        _repository = repository;
        _checkoutService = checkoutService;

        var expose = new Expose();
        _payment = expose.CreatePayment();
        _transactions = expose.CreateTransactions();
        _authority = expose.CreateAuthority();
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var regimen = await _repository.GetByIdAsync(id);

        var req = await _payment.Request(new DtoRequest()
        {
            Amount = 1000000,
            CallbackUrl = "http://127.0.0.1:5100/Regimens",
            MerchantId = "cfa83c81-89b0-4993-9445-2c3fcd323455",
            Description = "testjdchjsbcsdjhbcshjbcsdjhbcd",
            Email = "",
            Mobile = ""
        }, Payment.Mode.sandbox);

        return Redirect($"https://sandbox.zarinpal.com/pg/transation/startpay/{req.Authority}");
        //try
        //{
        //    return await _checkoutService.InitiatePaymentAsync(regimen.Price, regimen.Name);
        //}
        //catch (Exception ex)
        //{
        //    return BadRequest(new { Error = ex.Message });
        //}


    }
}
