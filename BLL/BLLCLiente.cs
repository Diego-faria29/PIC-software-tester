﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODELO;
using MySql.Data.MySqlClient;
using System.Data;
/*Business Logic Layer*/
namespace BLL
{
    public class BLLCLiente
    {
        private DALCliente DALcliente;

        public String mensagem = "";
        public BLLCLiente ( DALConection cx)
        {
            this.DALcliente = new DALCliente(cx);
        }

        public void Incluir (MODELOCliente modeloCliente)
        {
            try
            {
                string strPadrao2 = @"(^\d{3}\.\d{3}\.\d{3}\-\d{2}$)|(^\d{11}$)";
                if (!System.Text.RegularExpressions.Regex.IsMatch(modeloCliente.Cpf, strPadrao2))
                {
                    throw new ArgumentNullException("CPF", "CPF Inválido");
                }
                string strPadrao = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                if (!System.Text.RegularExpressions.Regex.IsMatch(modeloCliente.Email, strPadrao))
                {
                    throw new ArgumentNullException("Email", "E-mail Inválido");
                }
                if(modeloCliente.Nome == "")
                {
                    throw new ArgumentNullException("Nome", "Não pode ser vazio");
                }
                DALcliente.IncluirDados(modeloCliente);
            }
            catch (MySqlException error)
            {
                throw error;
            }
            catch (Exception error2)
            {
                throw error2;
            }
        }

        public void Alterar(MODELOCliente modeloCliente)
        {
            try
            {
                string strPadrao2 = @"(^\d{3}\.\d{3}\.\d{3}\-\d{2}$)|(^\d{11}$)";
                if (!System.Text.RegularExpressions.Regex.IsMatch(modeloCliente.Cpf, strPadrao2))
                {
                    throw new ArgumentNullException("CPF", "CPF Inválido");
                }
                string strPadrao = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                if (!System.Text.RegularExpressions.Regex.IsMatch(modeloCliente.Email, strPadrao))
                {
                    throw new ArgumentNullException("Email", "E-mail Inválido");
                }
                if (modeloCliente.Nome == "")
                {
                    throw new ArgumentNullException("Nome", "Não pode ser vazio");
                }
                DALcliente.Alterar(modeloCliente);
            }
            catch (MySqlException error)
            {
                throw error;
            }
            catch (Exception error2)
            {
                throw error2;
            }
        }

        public void Excluir(int codigo)
        {
            if(codigo <= 0)
            {
                
                throw new ArgumentNullException("ID", "Para deletar código, não pode estar zerado!");
            }
            DALcliente.Excluir(codigo);
        }

        public DataTable verificar(String nome)
        {
            if (!DALcliente.mensagem.Equals(""))
            {
                this.mensagem = DALcliente.mensagem;
            }
            return DALcliente.VefificarCadastro(nome);
        }
    }
}
