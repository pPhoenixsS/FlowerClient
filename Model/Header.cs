namespace FlowerClient.model
{
    public class Header
    {
        public string FingerPrint { get; set; }
        public string RefreshToken { get; set; }
        public string AccessToken { get; set; }

        public static Header headers = new Header();
    }
}
