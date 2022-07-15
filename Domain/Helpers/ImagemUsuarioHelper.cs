using Microsoft.Extensions.Hosting;
using System.IO;

namespace Domain.Helpers
{
    public class ImagemUsuarioHelper
    {
        private string _nomeImagem;
        private IHostEnvironment _host;

        public ImagemUsuarioHelper(string nomeImagem, IHostEnvironment host)
        {
            _nomeImagem = nomeImagem;
            _host = host;
        }

        public void ApagarImagem()
        {
            if (_nomeImagem is null) return;

            var imagemPath = Path.Combine(_host.ContentRootPath, @"Resources/Imagens", _nomeImagem);

            if (File.Exists(imagemPath))
            {
                File.Delete(imagemPath);
            }
        }
    }
}
