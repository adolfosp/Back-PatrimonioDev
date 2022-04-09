using Domain.Enums;

namespace Domain.Helpers
{
    public static class TratamentoRegistroSistema
    {
        public static bool EhRegistroPadraoSistema(EntidadesRegistroPadrao entidade, int codigoRegistro)
        {
            switch (entidade)
            {
                case EntidadesRegistroPadrao.Empresa:
                case EntidadesRegistroPadrao.Setor:
                case EntidadesRegistroPadrao.Funcionario:

                    if (codigoRegistro == 1)
                        return true;

                    return false;

                case EntidadesRegistroPadrao.Permissao:

                    if (codigoRegistro == 1 || codigoRegistro == 2 || codigoRegistro == 3)
                        return true;

                    return false;

                default:
                    return false;
            }
        }
    }
}
