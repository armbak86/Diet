namespace Diet.WebMVC.Services;

public class ZarinPalTestCheckoutService : ICheckoutService
{
    private const string merchant = "cfa83c81-89b0-4993-9445-2c3fcd323455";
    private string authority;
    private const string callbackurl = "http://localhost:5100/Regimens";
    private readonly HttpClient client;

    public ZarinPalTestCheckoutService(HttpClient httpClient)
    {
        client = httpClient;
    }


    public async Task<IActionResult> InitiatePaymentAsync(decimal amount, string description)
    {
        try
        {

            var parameters = new RequestParameters(merchant, amount.ToString(), description, callbackurl, "", "");

            var json = JsonConvert.SerializeObject(parameters);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(URLs.requestUrl, content);

            string responseBody = await response.Content.ReadAsStringAsync();

            JObject jo = JObject.Parse(responseBody);
            string errorscode = jo["errors"].ToString();

            JObject jodata = JObject.Parse(responseBody);
            string dataauth = jodata["data"].ToString();


            if (dataauth != "[]")
            {


                authority = jodata["data"]["authority"].ToString();

                string gatewayUrl = URLs.gateWayUrl + authority;

                return new RedirectResult(gatewayUrl);

            }
            else
            {

                return new BadRequestResult();


            }



        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);


        }
    }

    public async Task<bool> VerifyPaymentAsync(string authority, decimal amount)
    {
        //try
        //{

        //    VerifyParameters parameters = new VerifyParameters();


        //    if (HttpContext.Request.Query["Authority"] != "")
        //    {
        //        authority = HttpContext.Request.Query["Authority"];
        //    }

        //    parameters.authority = authority;

        //    parameters.amount = amount;

        //    parameters.merchant_id = merchant;


        //    using (HttpClient client = new HttpClient())
        //    {

        //        var json = JsonConvert.SerializeObject(parameters);

        //        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

        //        HttpResponseMessage response = await client.PostAsync(URLs.verifyUrl, content);

        //        string responseBody = await response.Content.ReadAsStringAsync();

        //        JObject jodata = JObject.Parse(responseBody);

        //        string data = jodata["data"].ToString();

        //        JObject jo = JObject.Parse(responseBody);

        //        string errors = jo["errors"].ToString();

        //        if (data != "[]")
        //        {
        //            string refid = jodata["data"]["ref_id"].ToString();

        //            ViewBag.code = refid;

        //            return View();
        //        }
        //        else if (errors != "[]")
        //        {

        //            string errorscode = jo["errors"]["code"].ToString();

        //            return BadRequest($"error code {errorscode}");

        //        }
        //    }



        //}
        //catch (Exception ex)
        //{

        //    throw ex;
        //}
        //return NotFound();

        return true;
    }
}

public class URLs
{
    public const String gateWayUrl = "https://www.zarinpal.com/pg/StartPay/";
    public const String requestUrl = "https://api.zarinpal.com/pg/v4/payment/request.json";
    public const String verifyUrl = "https://api.zarinpal.com/pg/v4/payment/verify.json";
}

public class VerifyParameters
{
    public string amount { set; get; }
    public string merchant_id { set; get; }
    public string authority { set; get; }
}

public class RequestParameters
{
    public string merchant_id { get; set; }

    public string amount { get; set; }
    public string description { get; set; }
    public string callback_url { get; set; }

    public string[]? metadata { get; set; }

    public RequestParameters(string merchant_id, string amount, string description, string callback_url, string? mobile, string? email)
    {
        this.merchant_id = merchant_id;
        this.amount = amount;
        this.description = description;
        this.callback_url = callback_url;
        this.metadata = new string[2];
        if (mobile != null)
        {
            this.metadata[0] = mobile;
        }
        if (email != null)
        {
            this.metadata[1] = email;
        }


    }
}