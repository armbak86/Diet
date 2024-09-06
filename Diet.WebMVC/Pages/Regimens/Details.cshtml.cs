namespace Diet.WebMVC.Pages.Regimens;

public class DetailsModel : PageModel
{
    private readonly IGenericRepository<Regimen> _repository;
    private readonly ICheckoutService _checkoutService;

    public DetailsModel(IGenericRepository<Regimen> repository, ICheckoutService checkoutService)
    {
        _repository = repository;
        _checkoutService = checkoutService;
    }

    [BindProperty]
    public Regimen Regimen { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
            return NotFound();

        Regimen = await _repository.GetByIdAsync((int)id);

        if (Regimen == null)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnGetCheckoutAsync()
    {
        try
        {
            return await _checkoutService.InitiatePaymentAsync(10000, "Regimen.Name");

            //var isSuccess = await _checkoutService.VerifyPaymentAsync(authority.ToString(), 10000);
            //return RedirectToPage("/Index");
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}
