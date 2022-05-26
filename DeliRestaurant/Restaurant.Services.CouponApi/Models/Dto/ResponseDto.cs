namespace Restaurant.Services.CouponApi.Models.Dto
{
    public class ResponseDto
    {
        public bool isSuccess { get; set; } = true;
        public dynamic Result { get; set; }

        public string DisplayMessage { get; set; }
        public List<string> ErrorMessages { get;set; }


    }
}
