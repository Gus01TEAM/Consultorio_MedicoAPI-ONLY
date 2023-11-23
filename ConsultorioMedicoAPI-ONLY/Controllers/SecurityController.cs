﻿using Consultorio_Medico.BL.DTOs.userDTO;
using Consultorio_Medico.BL.Interfaces;
using ConsultorioMedicoAPI_ONLY.DTOGenericResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsultorioMedicoAPI_ONLY.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly string secrectkey;
        private readonly ISecurityBL _securityBL;
        private readonly ILogger<SecurityController> _logger;

        DTOGenericResponse<securityDTO> DTOGenResponse = new DTOGenericResponse<securityDTO>();

        public SecurityController(ISecurityBL securityBL, ILogger<SecurityController> logger, IConfiguration config)
        {
            _securityBL = securityBL;
            _logger = logger;
            secrectkey = config.GetSection("settings").GetSection("secretkey").ToString();
        }

        // POST api/<SecurityController>
        [HttpPost]
        [Route("validate")]
        public IActionResult Post(LoginDTO login)
        {
            try
            {
                var security = _securityBL.Login(login);

                if (security.userId > 0)
                {
                    var KeyBytes = Encoding.ASCII.GetBytes(secrectkey);
                    var claims = new ClaimsIdentity();

                    claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, security.userName));

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = claims,
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(KeyBytes), SecurityAlgorithms.HmacSha256)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

                    string tokenCreado = tokenHandler.WriteToken(tokenConfig);

                    return StatusCode(StatusCodes.Status200OK, new { token = tokenCreado });

                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(true, "succesfully logged in.", security);
                    return Ok(pDTOGenResponse);

                }
                else
                {
                    var pDTOGenResponse = DTOGenResponse.GetGenericResponse(false, "Wrong credentials.", null);
                    //return StatusCode(StatusCodes.Status401Unauthorized);                  
                    return Ok(pDTOGenResponse);
                }
            }
            catch (Exception ex)
            {
                var DTOGenRes = DTOGenResponse.GetGenericResponse(false, "Error: " + ex.Message, null);
                return NotFound(DTOGenRes);
            }

        }
    }
}
