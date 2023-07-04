

namespace EmploymentSystem.Application.DTOs.Common
{
    public class ResponseDto
    {
        public ResponseDto()
        {

        }
        public ResponseDto(string responseMessage)
        {
            ResponseMessage = responseMessage;
        }

        public string ResponseMessage { get; set; }
       

    }
    


}
