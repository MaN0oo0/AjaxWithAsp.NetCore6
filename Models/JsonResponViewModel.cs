namespace Ajax_Crud_App.Models
{
    [Serializable]
    public class JsonResponViewModel
    {
        public int ResponseCode { get; set; }

        public string ResponseMessage { get; set; } = string.Empty;
    }
}
