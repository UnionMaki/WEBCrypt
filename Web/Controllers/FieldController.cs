using Domain;
using Domain.Entity;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Web.DTO;

namespace Web.Controllers;

[ApiController]
[Route( "[controller]" )]
public class FieldController : ControllerBase
{
    private readonly IFieldRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public FieldController( IFieldRepository userRepository, IUnitOfWork unitOfWork )
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }
    private class Crypt
    {
        private string Al = "�����Ũ����������������������������������������������������������";
        private string res;

        public void EnCrypt(ref string inputline)
        {
            res = string.Empty;
            foreach (char ch in inputline)
            {
                int i = 0;
                while (ch != Al[i])
                {
                    i++;
                }
                if (i == 0)
                    res += "�";
                else
                    if (i == 1)
                    res += "�";
                else
                        if (i == 33)
                    res += "�";
                else
                            if (i == 34)
                    res += "�";
                else
                    res += Al[i - 2];
            }
            inputline = res;

        }
        public void DeCrypt(ref string inputline)
        {
            res = string.Empty;
            foreach (char ch in inputline)
            {
                int i = 0;
                while (ch != Al[i])
                {
                    i++;
                }
                if (i == 31)
                    res += "�";
                else
                    if (i == 32)
                    res += "�";
                else
                        if (i == 64)
                    res += "�";
                else
                            if (i == 65)
                    res += "�";
                else
                    res += Al[i + 2];
            }
            inputline = res;

        }
    }

    [HttpGet]
    [Route("{FieldId}/getEncrypted")]
    public IActionResult RemoveUser(int FieldId)
    {
        Field? field = _userRepository.GetField(FieldId);
        if (field == null)
        {
            return BadRequest($"User with id {FieldId} not found");
        }
        string outLine = field.CryptedWord;
        Crypt crypter = new Crypt();
        crypter.DeCrypt(ref outLine);
        return Ok(outLine);
        


}

    [HttpGet( Name = "GetFields" )]
    public IEnumerable<Field> Get()
    {
        return _userRepository.GetAllFields();
    }

    [HttpPost( Name = "SaveField" )]
    public IActionResult SaveUser( FieldDto field )
    {

        Field domainField = new Field();
        string? inputLine = field.cryptedWord;
        Crypt crypter = new Crypt();
        crypter.EnCrypt(ref inputLine);
        domainField.CryptedWord = inputLine;

        _userRepository.AddField( domainField );
        _unitOfWork.Commit();

        return new OkResult();
    }
}
