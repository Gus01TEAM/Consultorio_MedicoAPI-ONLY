namespace ConsultorioMedicoAPI_ONLY.DTOGenericResponse
{
    
        public class DTOGenericResponse<T> where T : class
        {
            public bool Success { get; set; }
            public string Message { get; set; }
            public T? Data { get; set; }

            public DTOGenericResponse<T> GetGenericResponse(bool pSucces, string pMessage, T pData)
            {
                DTOGenericResponse<T> response = new DTOGenericResponse<T>();
                response.Message = pMessage;
                response.Data = pData;
                response.Success = pSucces;
                return response;
            }
        }
    }

