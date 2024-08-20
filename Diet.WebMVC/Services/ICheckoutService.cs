namespace Diet.WebMVC.Services;

public interface ICheckoutService
{
    Task<IActionResult> InitiatePaymentAsync(decimal amount, string description);
    Task<bool> VerifyPaymentAsync(string authority, decimal amount);
}
