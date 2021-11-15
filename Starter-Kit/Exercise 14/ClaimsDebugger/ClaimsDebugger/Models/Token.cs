   using System.Text;

   public class Token
    {
    public string access_token { get; set; } = "";
    public string id_token { get; set; } = "";
    public string expires_in { get; set; } = "";
    public string token_type { get; set; } = "";
    public string refresh_token { get; set; } = "";
    public string scope { get; set; } = "";

        public override string ToString()
        {
            StringBuilder O = new StringBuilder();
            O.Append($"access_token = {access_token}\r\n");
            O.Append($"id_token = {id_token}\r\n");
            O.Append($"expires_in = {expires_in}\r\n");
            O.Append($"token_type = {token_type}\r\n");
            O.Append($"refresh_token = {refresh_token}\r\n");
            O.Append($"scope = {scope}\r\n");

            return O.ToString();
        }
    }