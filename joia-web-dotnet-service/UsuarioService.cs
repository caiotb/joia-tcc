using joia_web_dotnet_infra;
using joia_web_dotnet_service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace joia_web_dotnet_service
{
    public class UsuarioService : IUsuarioService
    {
        public readonly joiaDbContext _dbContext;
      
        public UsuarioService(joiaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    
        public async Task<Dictionary<string, string>> GetUsuario(string nomeUsuario, string senha)
        {
            var encryptSenha = Encrypt(senha);
            var dict = new Dictionary<string, string>();
            var admin = await _dbContext.Administradores.Where(x => x.NomeUsuario.Equals(nomeUsuario) && x.Senha.Equals(encryptSenha)).FirstOrDefaultAsync();
            if(admin != null)
            {
                dict.Add(admin.NomeUsuario, "Admin");
                return dict;
            }
            else
            {
                var client = await _dbContext.Clientes.Where(x => x.NomeUsuario.Equals(nomeUsuario) && x.Senha.Equals(encryptSenha)).FirstOrDefaultAsync();
                if(client != null)
                {
                    dict.Add(client.NomeUsuario, "Client");
                    return dict;
                }
                else
                {
                    return  null;
                }
            }
        }
        private static string Encrypt(string senha)
        {           
            string textToEncrypt = senha;
            string ToReturn = "";
            string publickey = "12345678";
            string secretkey = "87654321";
            byte[] secretkeyByte = { };
            secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
            byte[] publickeybyte = { };
            publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
            MemoryStream ms = null;
            CryptoStream cs = null;
            byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                ms = new MemoryStream();
                cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                cs.FlushFinalBlock();
                ToReturn = Convert.ToBase64String(ms.ToArray());
            }
            return ToReturn;        
        }
    }
}
