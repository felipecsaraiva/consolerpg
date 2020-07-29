using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Threading;

namespace Consolerpg
{
    class Program
    {
        static void Main(string[] args)
        {
            bool play = true;
            bool logado = false;
            string comando = "";
            int idPersonagem = 0;

            int maximaCarga = 40;
            int idNorte = 0;
            int idSul = 0;
            int idLeste = 0;
            int idOeste = 0;
            int idLoja = 0;
            int idEstalagem = 0;
            int idFerreiro = 0;
            int idTenda = 0;
            int idAreaAtual = 0;
            int idDepot = 0;

            string scomandos = ".v/.p";
            string ocomandos = "revive/moneyboost/xpboost/evolucro/entrar/sair/.drop/.get/.eq/.deq/.f/.up/.per/.forja/.fj/.alquimia/.al/.u/.exam/.quest/.criar/.resp/.mapa/.teleporte/.minerar";

            Console.WriteLine("###########################################################");
            Console.WriteLine("################### C-O-N-S-0-L-E-R-P-G ###################");
            Console.WriteLine("##################################################v.1.0####");

            try
            {
                while (play)
                {
                    if (!logado)
                    {
                        Console.Write("Comando [entrar/sair]: ");
                        comando = Console.ReadLine();
                    }
                    else
                    {
                        if (idPersonagem.Equals(0))
                        {
                            Console.WriteLine("Bem vindo à CONSOLE, um mundo de fantasia e aventuras.");
                            OdbcDataReader reader = DbUtilities.doSelect("tb_personagem", "", "", "id_personagem", "id_personagem > 0 ORDER BY id_personagem DESC");
                            if (reader.Read())
                            {
                                idPersonagem = Convert.ToInt32(reader["id_personagem"]);
                            }
                        }
                        
                        OdbcDataReader rcomandos = DbUtilities.doSelect("tb_personagem", "tb_area", "a.id_area = b.id_area", "*", "a.id_personagem = " + idPersonagem);
                        scomandos = ".v/.p";
                        if (rcomandos.Read())
                        {
                            idAreaAtual = Convert.ToInt32(rcomandos["id_area"]);
                            idNorte = Convert.ToInt32(rcomandos["id_norte"]);
                            idSul = Convert.ToInt32(rcomandos["id_sul"]);
                            idLeste = Convert.ToInt32(rcomandos["id_leste"]);
                            idOeste = Convert.ToInt32(rcomandos["id_oeste"]);
                            idLoja = Convert.ToInt32(rcomandos["id_loja"]);
                            idEstalagem = Convert.ToInt32(rcomandos["id_estalagem"]);
                            scomandos += "/" + rcomandos["tx_comandos"].ToString();
                            idFerreiro = Convert.ToInt32(rcomandos["id_ferreiro"]);
                            idTenda = Convert.ToInt32(rcomandos["id_alquimista"]);
                            idDepot = Convert.ToInt32(rcomandos["id_deposito"]);
                        }
                        Console.Write("Comando [" + scomandos + "]: ");
                        comando = Console.ReadLine();
                    }
                    if (comando.Equals("niveis"))
                    {
                        int nivelAtual = 1;
                        int ExpNext = 0;

                        while (nivelAtual <= 100)
                        {
                            ExpNext = Convert.ToInt32(Math.Round((80.000000000 / 3) * Math.Pow(nivelAtual, 3) - (80 * Math.Pow(nivelAtual, 2)) + ((850.000000000 / 3) * nivelAtual - 210)));

                            Console.WriteLine(nivelAtual + "    " + ExpNext);
                            nivelAtual++;
                        }
                    }
                    if (comando.Equals("testar"))
                    {
                        ConsoleServer.ConsoleServerClient server = new ConsoleServer.ConsoleServerClient();
                        int ret = server.LoginUser("2", "2");

                        string[] personagem = new string[11];
                        if (ret > 0)
                        {
                            personagem = server.getUserData(ret);
                            Console.WriteLine(personagem[0]);
                        }

                        string[] area = server.getAreaData(Convert.ToInt32(personagem[2]));
                        Console.WriteLine(area[0] + ": " + area[1]);
                    }

                    if (scomandos.Contains(comando) || ocomandos.Contains(comando) || comando.Substring(0,1).Equals("!"))
                    {

                        if (comando.Equals("revive"))
                        {
                            DbUtilities.doUpdate("tb_personagem", "nr_hp = nr_hp_max, nr_mp = nr_mp_max", "id_personagem = " + idPersonagem);
                            Console.WriteLine("    ********************************");
                            Console.WriteLine(" ***************************************");
                            Console.WriteLine("****    VOCÊ RECUPEROU SUAS ENERGIAS   ****");
                            Console.WriteLine(" ***************************************");
                            Console.WriteLine("    ********************************");
                        }
                        if (comando.Equals("moneyboost"))
                        {
                            DbUtilities.doUpdate("tb_personagem","nr_ouro = nr_ouro + 1000","id_personagem = " + idPersonagem);
                            Console.WriteLine("    *************************");
                            Console.WriteLine(" *******************************");
                            Console.WriteLine("****    VOCÊ ACHOU 1000g     ****");
                            Console.WriteLine(" *******************************");
                            Console.WriteLine("    *************************");
                        }
                        if (comando.Equals("xpboost"))
                        {
                            DbUtilities.doUpdate("tb_personagem", "nr_exp = nr_exp + 1000", "id_personagem = " + idPersonagem);
                            Console.WriteLine("    *************************");
                            Console.WriteLine(" *******************************");
                            Console.WriteLine("****    VOCÊ GANHOU 1000xp     ****");
                            Console.WriteLine(" *******************************");
                            Console.WriteLine("    *************************");
                        }

                        if (comando.Equals("evolucro"))
                        {
                            DbUtilities.doUpdate("tb_personagem", "nr_pontos_atributo = nr_pontos_atributo + 1", "id_personagem = " + idPersonagem);
                            Console.WriteLine("    *************************");
                            Console.WriteLine(" *******************************");
                            Console.WriteLine("****Aumento 1 ponto de atributo****");
                            Console.WriteLine(" *******************************");
                            Console.WriteLine("    *************************");
                        }

                        if (comando.Equals("sair"))
                        {
                            Console.Write("Confirmar saída do jogo? [S/N]: ");
                            comando = Console.ReadLine();
                            if (comando.Equals("S"))
                            {
                                play = false;
                                comando = "";
                            }
                        }

                        if (comando.Equals("entrar"))
                        {
                            Console.Write("Login: ");
                            string login = Console.ReadLine();

                            OdbcDataReader reader = DbUtilities.doSelect("tb_personagem", "", "", "id_personagem,tx_senha", "tx_login = '" + login + "'");
                            if (reader.Read())
                            {
                                Console.Write("Senha: ");
                                string senha = Console.ReadLine();
                                if (senha.Equals(reader["tx_senha"].ToString()))
                                {
                                    logado = true;
                                    idPersonagem = Convert.ToInt32(reader["id_personagem"]);
                                }
                            }
                            else
                            {
                                Console.Write("Este login não existe, deseja criar? [S/N]: ");
                                comando = Console.ReadLine();
                                if (comando.Equals("S"))
                                {
                                    string personagem = "";
                                    while (personagem.Equals(""))
                                    {
                                        Console.Write("Escolha um nome para o seu personagem: ");
                                        personagem = Console.ReadLine();
                                        OdbcDataReader nomepersonagem = DbUtilities.doSelect("tb_personagem", "", "", "*", "tx_nome = '" + personagem + "'");
                                        if (nomepersonagem.Read())
                                        {
                                            personagem = "";
                                            Console.WriteLine("Já existe um personagem com este nome, escolha outro.");
                                        }
                                    }

                                    Console.Write("Escolha uma senha: ");
                                    comando = Console.ReadLine();
                                    DbUtilities.doInsert("tb_personagem", "tx_nome,tx_login,tx_senha,id_area,nr_nivel,nr_exp,nr_exp_next,nr_ouro,nr_hp,nr_hp_max,nr_mp,nr_mp_max,nr_ataque,nr_defesa,nr_agilidade,nr_destreza,nr_inteligencia,nr_vitalidade,nr_composicao,nr_concentracao,nr_pontos_atributo,tx_premium,id_tipoefeito,nr_variavel,nr_contaefeito,st_descansando", "'" + personagem + "','" + login + "','" + comando + "',1,1,0,100,100,65,65,30,30,5,5,5,5,5,5,5,5,0,'N','',0,0,'N'");
                                    DbUtilities.doInsert("tb_item_area", "id_item,id_area", "1,1");
                                    OdbcDataReader criado = DbUtilities.doSelect("tb_personagem", "", "", "id_personagem", "tx_login = '" + login + "'");
                                    if (criado.Read())
                                    {
                                        int idp = Convert.ToInt32(criado["id_personagem"]);
                                        DbUtilities.doInsert("tb_deposito", "id_personagem,id_item,id_area", idp + ",3,9");
                                        DbUtilities.doInsert("tb_deposito", "id_personagem,id_item,id_area", idp + ",4,9");
                                    }
                                    logado = true;
                                }
                            }

                        }

                        if (comando.Equals(".minerar"))
                        {
                            bool temPicareta = false;
                            int modMinerar = 0;
                            int segundos = 0;

                            OdbcDataReader inv = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "a.id_personagem = " + idPersonagem + " AND a.tx_equipado != '' AND b.tx_nome like '%Picareta%'");
                            if (inv.Read())
                            {
                                temPicareta = true;
                                modMinerar = Convert.ToInt32(inv["nr_taxamineracao"]);
                                segundos = Convert.ToInt32(inv["nr_segundos"]);
                            }

                            if (temPicareta)
                            {
                                Thread mine = new Thread(delegate () { doMine(modMinerar, idAreaAtual, idPersonagem, segundos); });
                                
                                mine.Start();
                                Console.WriteLine("Você está minerando... Prescione ENTER quando quiser parar.");
                                Console.ReadLine();
                                mine.Abort();
                                Console.WriteLine("Você parou de minerar.");
                            }
                            else
                            {
                                Console.WriteLine("Você precisa estar equipado com uma Picareta para minerar aqui.");
                            }
                        }

                        if (comando.Equals(".area"))
                        {

                            string nome = "";
                            string descricao = "";
                            
                            Console.WriteLine("Você está criando uma nova área. Em qual direção ela será criada? (N,S,L,O): ");
                            comando = Console.ReadLine();
                            if (comando.Equals("S"))
                            {
                                if (idSul == 0)
                                {
                                    Console.WriteLine("Dê um título para a nova area:");
                                    nome = Console.ReadLine();
                                    Console.WriteLine("Descreva a nova area:");
                                    descricao = Console.ReadLine();
                                    DbUtilities.doInsert("tb_area", "tx_nome,tx_descricao,id_norte,id_sul,id_leste,id_oeste,tx_comandos", "'" + nome + "','" + descricao + "'," + idAreaAtual + ",0,0,0,'.n'");

                                }
                                else
                                {
                                    Console.WriteLine("Já existe uma area ao Sul.");
                                }
                            }
                        }

                        if (comando.Equals(".teleporte"))
                        {
                            Console.Write("Local? ");
                            comando = Console.ReadLine();
                            DbUtilities.doUpdate("tb_personagem", "id_area = " + comando, "id_personagem = " + idPersonagem);
                            Console.WriteLine("Zuuuum!!");
                        }

                        if (comando.Equals(".p"))
                        {
                            string ataque = "";
                            string defesa = "";
                            string agilidade = "";
                            string destreza = "";
                            string inteligencia = "";
                            string vitalidade = "";
                            string composicao = "";
                            string concentracao = "";
                            int atkEfeito = 0;
                            int defEfeito = 0;
                            int agiEfeito = 0;
                            int desEfeito = 0;
                            int intEfeito = 0;
                            int vitEfeito = 0;
                            int comEfeito = 0;
                            int conEfeito = 0;
                            int nivelPlay = 0;
                            bool estaEfeito = false;
                            string tipoEfeito = "";

                            OdbcDataReader reader = DbUtilities.doSelect("tb_personagem", "", "", "*", "id_personagem = " + idPersonagem);
                            if (reader.Read())
                            {
                                Console.WriteLine("+--------------------------- Perfil ---------------------------+");
                                Console.WriteLine(("| Nome: " + reader["tx_nome"].ToString()).PadRight(43,' ') +   ("     O  [1]").PadRight(20,' ') + "|");
                                Console.WriteLine(("| Nível: " + reader["nr_nivel"].ToString()).PadRight(43,' ') + ("[2] /|\\ [3]").PadRight(20,' ') + "|");
                                Console.WriteLine(("| HP: " + reader["nr_hp"].ToString() + "/" + reader["nr_hp_max"].ToString()).PadRight(43,' ') + ("     |  [4]").PadRight(20,' ') + "|");
                                Console.WriteLine(("| MP: " + reader["nr_mp"].ToString() + "/" + reader["nr_mp_max"].ToString()).PadRight(43, ' ') + ("    / \\ [5]").PadRight(20,' ')  + "|");
                                Console.WriteLine(("| Ouro: " + reader["nr_ouro"].ToString() + "g").PadRight(63, ' ') + "|");
                                Console.WriteLine(("| Experiência: " + reader["nr_exp"].ToString() + "/" + reader["nr_exp_next"].ToString()).PadRight(63, ' ') + "|");
                                Console.WriteLine(("| Pontos de atributo: " + reader["nr_pontos_atributo"].ToString()).PadRight(63, ' ') + "|");
                                nivelPlay = Convert.ToInt32(reader["nr_nivel"]);
                                ataque = reader["nr_ataque"].ToString();
                                defesa = reader["nr_defesa"].ToString();
                                agilidade = reader["nr_agilidade"].ToString();
                                destreza = reader["nr_destreza"].ToString();
                                inteligencia = reader["nr_inteligencia"].ToString();
                                vitalidade = reader["nr_vitalidade"].ToString();
                                composicao = reader["nr_composicao"].ToString();
                                concentracao = reader["nr_concentracao"].ToString();
                                if (Convert.ToInt32(reader["nr_contaefeito"]) > 0)
                                {
                                    if (reader["id_tipoefeito"].ToString().Equals("A"))
                                    {
                                        atkEfeito = (Convert.ToInt32(ataque) * Convert.ToInt32(reader["nr_variavel"])) / 100;
                                    }
                                    if (reader["id_tipoefeito"].ToString().Equals("D"))
                                    {
                                        defEfeito = (Convert.ToInt32(defesa) * Convert.ToInt32(reader["nr_variavel"])) / 100;
                                    }

                                    if (reader["id_tipoefeito"].ToString().Equals("X"))
                                    {
                                        agiEfeito = (Convert.ToInt32(agilidade) * Convert.ToInt32(reader["nr_variavel"])) / 100;
                                    }

                                    if (reader["id_tipoefeito"].ToString().Equals("Z"))
                                    {
                                        desEfeito = (Convert.ToInt32(destreza) * Convert.ToInt32(reader["nr_variavel"])) / 100;
                                    }

                                    if (reader["id_tipoefeito"].ToString().Equals("I"))
                                    {
                                        intEfeito = (Convert.ToInt32(inteligencia) * Convert.ToInt32(reader["nr_variavel"])) / 100;
                                    }

                                    if (reader["id_tipoefeito"].ToString().Equals("V"))
                                    {
                                        vitEfeito = (Convert.ToInt32(vitalidade) * Convert.ToInt32(reader["nr_variavel"])) / 100;
                                    }

                                    if (reader["id_tipoefeito"].ToString().Equals("P"))
                                    {
                                        comEfeito = (Convert.ToInt32(composicao) * Convert.ToInt32(reader["nr_variavel"])) / 100;
                                    }

                                    if (reader["id_tipoefeito"].ToString().Equals("C"))
                                    {
                                        conEfeito = (Convert.ToInt32(concentracao) * Convert.ToInt32(reader["nr_variavel"])) / 100;
                                    }

                                    estaEfeito = true;
                                    tipoEfeito = reader["id_tipoefeito"].ToString();
                                }
                            }
                            OdbcDataReader itens = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "a.id_personagem = " + idPersonagem + " AND tx_equipado != ''");

                            int maisAtk = atkEfeito;
                            int maisDef = defEfeito;
                            int maisAgi = agiEfeito;
                            int maisDes = desEfeito;
                            int maisInt = intEfeito;
                            int maisVit = vitEfeito;
                            int maisCom = comEfeito;
                            int maisCon = conEfeito;
                            int danoItem = 0;
                            string classeItem = "";
                            while (itens.Read())
                            {
                                maisAtk += Convert.ToInt32(itens["nr_ataque"]);
                                maisDef += Convert.ToInt32(itens["nr_defesa"]);
                                maisAgi += Convert.ToInt32(itens["nr_agilidade"]);
                                maisDes += Convert.ToInt32(itens["nr_destreza"]);
                                maisInt += Convert.ToInt32(itens["nr_inteligencia"]);
                                maisVit += Convert.ToInt32(itens["nr_vitalidade"]);
                                maisCom += Convert.ToInt32(itens["nr_composicao"]);
                                maisCon += Convert.ToInt32(itens["nr_concentracao"]);
                                if (!itens["id_classe"].ToString().Equals(""))
                                {
                                    classeItem = itens["id_classe"].ToString();
                                }
                                danoItem += Convert.ToInt32(itens["nr_dano"]);
                            }

                            string tipoUpPer = "";
                            int ataquePer = 0;
                            int defesaPer = 0;
                            int agiPer = 0;
                            int desPer = 0;
                            int vitPer = 0;
                            int intPer = 0;
                            int comPer = 0;
                            int conPer = 0;
                            int hpPer = 0;
                            int danoPer = 0;
                            OdbcDataReader perAtual = DbUtilities.doSelect("tb_pericia_personagem", "tb_pericia", "a.id_pericia = b.id_pericia", "*", "a.st_situacao = 'O' AND a.id_personagem = " + idPersonagem + " AND id_classe = '" + classeItem + "'");
                            if (perAtual.Read())
                            {
                                tipoUpPer = perAtual["id_tipo"].ToString();
                                ataquePer = Convert.ToInt32(perAtual["nr_ataque"]);
                                defesaPer = Convert.ToInt32(perAtual["nr_defesa"]);
                                agiPer = Convert.ToInt32(perAtual["nr_agilidade"]);
                                desPer = Convert.ToInt32(perAtual["nr_destreza"]);
                                intPer = Convert.ToInt32(perAtual["nr_inteligencia"]);
                                vitPer = Convert.ToInt32(perAtual["nr_vitalidade"]);
                                comPer = Convert.ToInt32(perAtual["nr_composicao"]);
                                conPer = Convert.ToInt32(perAtual["nr_concentracao"]);
                                hpPer = Convert.ToInt32(perAtual["nr_hp"]);
                                danoPer = Convert.ToInt32(perAtual["nr_dano"]);
                            }

                            if (tipoUpPer.Equals("V"))
                            {
                                maisAtk += ataquePer;
                                maisDef += defesaPer;
                                maisAgi += agiPer;
                                maisDes += desPer;
                                maisInt += intPer;
                                maisVit += vitPer;
                                maisCom += comPer;
                                maisCon += conPer;
                            }
                            if (tipoUpPer.Equals("P"))
                            {
                                ataquePer = (Convert.ToInt32(ataque) * ataquePer) / 100;
                                maisAtk += ataquePer;

                                defesaPer = (Convert.ToInt32(defesa) * defesaPer) / 100;
                                maisDef += defesaPer;

                                agiPer = (Convert.ToInt32(agilidade) * agiPer) / 100;
                                maisAgi += agiPer;

                                desPer = (Convert.ToInt32(destreza) * desPer) / 100;
                                maisDes += desPer;

                                intPer = (Convert.ToInt32(inteligencia) * intPer) / 100;
                                maisInt += intPer;

                                vitPer = (Convert.ToInt32(vitalidade) * vitPer) / 100;
                                maisVit += vitPer;

                                comPer = (Convert.ToInt32(composicao) * comPer) / 100;
                                maisCom += comPer;

                                conPer = (Convert.ToInt32(concentracao) * conPer) / 100;
                                maisCon += conPer;
                            }

                            int atkPlay = Convert.ToInt32(ataque) + maisAtk;
                            int defPlay = Convert.ToInt32(defesa) + maisDef;
                            int agiPlay = Convert.ToInt32(agilidade) + maisAgi;
                            int desPlay = Convert.ToInt32(destreza) + maisDes;
                            int intPlay = Convert.ToInt32(inteligencia) + maisInt;
                            int vitPlay = Convert.ToInt32(vitalidade) + maisVit;
                            int comPlay = Convert.ToInt32(composicao) + maisCom;
                            int conPlay = Convert.ToInt32(concentracao) + maisCon;

                            if (maisAtk > 0)
                            {
                                ataque += " +" + maisAtk.ToString();
                            }
                            if (maisDef > 0)
                            {
                                defesa += " +" + maisDef.ToString();
                            }
                            if (maisAgi > 0)
                            {
                                agilidade += " +" + maisAgi.ToString();
                            }
                            if (maisDes > 0)
                            {
                                destreza += " +" + maisDes.ToString();
                            }
                            if (maisInt > 0)
                            {
                                inteligencia += " +" + maisInt.ToString();
                            }
                            if (maisVit > 0)
                            {
                                vitalidade += " +" + maisVit.ToString();
                            }
                            if (maisCom > 0)
                            {
                                composicao += " +" + maisCom.ToString();
                            }
                            if (maisCon > 0)
                            {
                                concentracao += " +" + maisCon.ToString();
                            }


                            if (maisAtk < 0)
                            {
                                ataque += " " + maisAtk.ToString();
                            }
                            if (maisDef < 0)
                            {
                                defesa += " " + maisDef.ToString();
                            } 
                            if (maisAgi < 0)
                            {
                                agilidade += " " + maisAgi.ToString();
                            }
                            if (maisDes < 0)
                            {
                                destreza += " " + maisDes.ToString();
                            }
                            if (maisVit < 0)
                            {
                                vitalidade += " " + maisVit.ToString();
                            }
                            if (maisInt < 0)
                            {
                                inteligencia += " " + maisInt.ToString();
                            }
                            if (maisCom < 0)
                            {
                                composicao += " " + maisCom.ToString();
                            }
                            if (maisCon < 0)
                            {
                                concentracao += " " + maisCon.ToString();
                            }

                            Console.WriteLine(("|").PadRight(63, ' ') + "|");
                            Console.WriteLine((("| FOR: " + ataque).PadRight(17,' ') + " INT: " + inteligencia).PadRight(63, ' ') + "|");
                            Console.WriteLine((("| VIT: " + vitalidade).PadRight(17, ' ') + " COM: " + composicao).PadRight(63, ' ') + "|");
                            Console.WriteLine((("| AGI: " + agilidade).PadRight(17, ' ') + " DES: " + destreza).PadRight(63, ' ') + "|");
                            Console.WriteLine((("| RES: " + defesa).PadRight(17, ' ') + " CON: " + concentracao).PadRight(63, ' ') + "|");
                            Console.WriteLine(("|").PadRight(63, ' ') + "|");

                            int danoMaxPlayer = 0;
                            int acertaPlay = 0;
                            int escapaPlay = 0;

                            if (classeItem.Equals("M"))
                            {
                                danoMaxPlayer = (nivelPlay * 500) + (intPlay * 500) + (conPlay * 300);
                                acertaPlay = (nivelPlay * 500) + (conPlay * 600) + (desPlay * 600);
                            }
                            else
                            {
                                if (classeItem.Equals("D"))
                                {
                                    danoMaxPlayer = (nivelPlay * 500) + (atkPlay * 500) + (desPlay * 700);
                                    acertaPlay = (nivelPlay * 500) + (desPlay * 1400);
                                }
                                else
                                {
                                    danoMaxPlayer = (nivelPlay * 500) + (atkPlay * 800) + (desPlay * 400);
                                    acertaPlay = (nivelPlay * 500) + (desPlay * 600) + (atkPlay * 600);
                                }
                            }

                            int resMaxPlayer = (nivelPlay * 500) + (defPlay * 800) + (atkPlay * 500);
                            if (classeItem.Equals("M"))
                            {
                                resMaxPlayer = (nivelPlay * 800) + (defPlay * 500) + (atkPlay * 200);
                            }

                            danoMaxPlayer = danoMaxPlayer / 1000;
                            acertaPlay = acertaPlay / 1000;
                            resMaxPlayer = resMaxPlayer / 1000;
                            danoMaxPlayer += danoItem;
                            escapaPlay = Convert.ToInt32((nivelPlay * 1.8) + (agiPlay*1.8)) - 6;

                            Console.WriteLine(("| Dano: " + (danoMaxPlayer * 60) / 100 + " ~ " + danoMaxPlayer).PadRight(63, ' ') + "|");
                            Console.WriteLine(("| Proteção: 0 ~ " + resMaxPlayer).PadRight(63, ' ') + "|");
                            Console.WriteLine(("| Chance de acerto: 0 ~ " + acertaPlay).PadRight(63, ' ') + "|");
                            Console.WriteLine(("| Esquiva: 0 ~ " + escapaPlay).PadRight(63, ' ') + "|");

                            if (estaEfeito)
                            {
                                Console.WriteLine("|                                                              |");
                                Console.WriteLine(("| Você está sob efeito de alguma magia.").PadRight(63, ' ') + "|");
                                if (tipoEfeito.Equals("A"))
                                    Console.WriteLine(("| >Sua força sofreu alterações.").PadRight(63, ' ') + "|");
                                if (tipoEfeito.Equals("D"))
                                    Console.WriteLine(("| >Sua resistência sofreu alterações.").PadRight(63, ' ') + "|");
                                if (tipoEfeito.Equals("G"))
                                    Console.WriteLine(("| >Seu ganho em ouro será maior ao enfrentar criaturas.").PadRight(63, ' ') + "|");
                                if (tipoEfeito.Equals("L"))
                                    Console.WriteLine(("| >A chance das criaturas derrubarem algum item é maior.").PadRight(63, ' ') + "|");
                                if (tipoEfeito.Equals("E"))
                                    Console.WriteLine(("| >Seu ganho de experiência será maior ao enfrentar criaturas.").PadRight(63, ' ') + "|");
                                if (tipoEfeito.Equals("X"))
                                    Console.WriteLine(("| >Sua agilidade sofreu alterações.").PadRight(63, ' ') + "|");
                                if (tipoEfeito.Equals("Z"))
                                    Console.WriteLine(("| >Sua destreza sofreu alterações.").PadRight(63, ' ') + "|");
                                if (tipoEfeito.Equals("I"))
                                    Console.WriteLine(("| >Sua inteligencia sofreu alterações.").PadRight(63, ' ') + "|");
                                if (tipoEfeito.Equals("V"))
                                    Console.WriteLine(("| >Sua vitalidade sofreu alterações.").PadRight(63, ' ') + "|");
                                if (tipoEfeito.Equals("P"))
                                    Console.WriteLine(("| >Sua composição sofreu alterações.").PadRight(63, ' ') + "|");
                                if (tipoEfeito.Equals("C"))
                                    Console.WriteLine(("| >Sua concentração sofreu alterações.").PadRight(63, ' ') + "|");
                            }
                            Console.WriteLine("+------------------------- Inventario -------------------------+");
                            OdbcDataReader inv = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "b.id_tipo NOT IN ('I','M') AND a.id_personagem = " + idPersonagem + " ORDER BY tx_equipado DESC");
                            while (inv.Read())
                            {
                                string atdef = "";
                                /*
                                if (Convert.ToInt32(inv["nr_ataque"]) > 0)
                                {
                                    atdef = "(+" + inv["nr_ataque"].ToString() + ",";
                                }
                                else
                                {
                                    if (Convert.ToInt32(inv["nr_ataque"]) < 0)
                                        atdef = "(" + inv["nr_ataque"].ToString() + ",";
                                    else
                                        atdef = "(+0,";
                                }

                                if (Convert.ToInt32(inv["nr_defesa"]) > 0)
                                {
                                    atdef += "+" + inv["nr_defesa"].ToString() + ")";
                                }
                                else
                                {
                                    if (Convert.ToInt32(inv["nr_defesa"]) < 0)
                                        atdef += inv["nr_defesa"].ToString() + ")";
                                    else
                                        atdef += "+0)";
                                }*/

                                Console.WriteLine(("| " + inv["tx_nome"].ToString() + inv["tx_equipado"].ToString()).PadRight(63,' ') + "|");
                            }
                            OdbcDataReader its = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "b.tx_nome, count(*) qt", "b.id_tipo IN ('I','M') AND a.id_personagem = " + idPersonagem + " GROUP BY b.tx_nome ORDER BY b.tx_nome");
                            while (its.Read())
                            {
                                Console.WriteLine(("| " + its["qt"] + "x " + its["tx_nome"].ToString()).PadRight(63, ' ') + "|"); 
                            }
                            Console.WriteLine("+--------------------------------------------------------------+");
                        }

                        if (comando.Equals(".per"))
                        {
                            OdbcDataReader perAtual = DbUtilities.doSelect("tb_pericia_personagem", "tb_pericia", "a.id_pericia = b.id_pericia", "*", "a.st_situacao = 'O' AND a.id_personagem = " + idPersonagem);
                            Console.WriteLine("+-------------------------Perícias-----------------------------+");
                            while (perAtual.Read())
                            {
                                Console.WriteLine(("| " + perAtual["tx_nome"].ToString()).PadRight(63,' ') + "|");
                                Console.WriteLine(("| > " + perAtual["tx_descricao"].ToString()).PadRight(63, ' ') + "|");
                            }
                            OdbcDataReader perAnd = DbUtilities.doSelect("tb_pericia_personagem", "tb_pericia", "a.id_pericia = b.id_pericia", "*", "a.st_situacao = 'X' AND a.id_personagem = " + idPersonagem);
                            Console.WriteLine("+-----------------------Em andamento---------------------------+");
                            while (perAnd.Read())
                            {
                                int xx = (Convert.ToInt32(perAnd["nr_atual"]) * 100) / Convert.ToInt32(perAnd["nr_necessario"]);
                                Console.WriteLine(("| " + perAnd["tx_nome"].ToString()).PadRight(53, ' ') + (xx.ToString() + "%").PadRight(10,' ') + "|");
                            }
                            Console.WriteLine("+--------------------------------------------------------------+");
                        }

                        if (comando.Equals(".exam"))
                        {
                            Console.Write("Que item deseja examinar?: ");
                            comando = Console.ReadLine();
                            OdbcDataReader inv = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "a.id_personagem = " + idPersonagem + " AND b.tx_nome like '%" + comando + "%'");

                            int idItemExam = 0;

                            if (inv.Read())
                            {
                                idItemExam = Convert.ToInt32(inv["id_item"]);
                            }
                            else
                            {
                                OdbcDataReader itens = DbUtilities.doSelect("tb_loja", "tb_item", "a.id_item = b.id_item", "*", "a.id_area = " + idAreaAtual + " AND b.tx_nome like '%" + comando + "%'");
                                if (itens.Read())
                                {
                                    idItemExam = Convert.ToInt32(itens["id_item"]);
                                }
                                else
                                {
                                    OdbcDataReader chao = DbUtilities.doSelect("tb_item_area", "tb_item", "a.id_item = b.id_item", "*", "b.tx_nome like '%" + comando + "%' AND a.id_area = " + idAreaAtual);
                                    if (chao.Read())
                                    {
                                        idItemExam = Convert.ToInt32(chao["id_item"]);
                                    }
                                }
                            }

                            if (idItemExam > 0)
                            {
                                OdbcDataReader exa = DbUtilities.doSelect("tb_item","","","*","id_item = " + idItemExam);
                                if (exa.Read())
                                {
                                    Console.WriteLine("Você examinou " + exa["tx_nome"].ToString() + "...");
                                    Console.WriteLine(exa["tx_descricao"].ToString());
                                    
                                    if (!exa["id_tipo"].ToString().Equals("M") && !exa["id_tipo"].ToString().Equals("I"))
                                    {
                                        Console.WriteLine("+--------------------------------------------------------------+");
                                        Console.WriteLine(("| " + exa["tx_nome"].ToString()).PadRight(63, ' ') + "|");
                                        Console.WriteLine("+--------------------------------------------------------------+");
                                        if (Convert.ToInt32(exa["nr_ataque"]) > 0)
                                            Console.WriteLine(("| FOR: +" + exa["nr_ataque"].ToString()).PadRight(63, ' ') + "|");
                                        if (Convert.ToInt32(exa["nr_inteligencia"]) > 0)
                                            Console.WriteLine(("| INT: +" + exa["nr_inteligencia"].ToString()).PadRight(63, ' ') + "|");
                                        if (Convert.ToInt32(exa["nr_agilidade"]) > 0)
                                            Console.WriteLine(("| AGI: +" + exa["nr_agilidade"].ToString()).PadRight(63, ' ') + "|");
                                        if (Convert.ToInt32(exa["nr_destreza"]) > 0)
                                            Console.WriteLine(("| DES: +" + exa["nr_destreza"].ToString()).PadRight(63, ' ') + "|");
                                        if (Convert.ToInt32(exa["nr_vitalidade"]) > 0)
                                            Console.WriteLine(("| VIT: +" + exa["nr_vitalidade"].ToString()).PadRight(63, ' ') + "|");
                                        if (Convert.ToInt32(exa["nr_composicao"]) > 0)
                                            Console.WriteLine(("| COM: +" + exa["nr_composicao"].ToString()).PadRight(63, ' ') + "|");
                                        if (Convert.ToInt32(exa["nr_defesa"]) > 0)
                                            Console.WriteLine(("| RES: +" + exa["nr_defesa"].ToString()).PadRight(63, ' ') + "|");
                                        if (Convert.ToInt32(exa["nr_concentracao"]) > 0)
                                            Console.WriteLine(("| CON: +" + exa["nr_concentracao"].ToString()).PadRight(63, ' ') + "|");

                                        if (Convert.ToInt32(exa["nr_dano"]) > 0)
                                            Console.WriteLine(("| Dano: " + (Convert.ToInt32(exa["nr_dano"]) * 60) / 100 + " ~ " + exa["nr_dano"].ToString()).PadRight(63, ' ') + "|");

                                        string tipo = exa["id_tipo"].ToString();

                                        if (tipo.Equals("W"))
                                            tipo = "Armamento";
                                        if (tipo.Equals("C"))
                                            tipo = "Capacete";
                                        if (tipo.Equals("A"))
                                            tipo = "Armadura";
                                        if (tipo.Equals("B"))
                                            tipo = "Botas";
                                        if (tipo.Equals("E"))
                                            tipo = "Escudo";

                                        string classe = exa["id_classe"].ToString();
                                        if (classe.Equals("S"))
                                        {
                                            classe = "Espada";
                                        } 
                                        if (classe.Equals("A"))
                                        {
                                            classe = "Machado";
                                        } 
                                        if (classe.Equals("C"))
                                        {
                                            classe = "Clava";
                                        }
                                        if (classe.Equals("D"))
                                        {
                                            classe = "Distância";
                                        } 
                                        if (classe.Equals("M"))
                                        {
                                            classe = "Mágico";
                                        }
                                        if (!classe.Equals(""))
                                        {
                                            Console.WriteLine(("| Classe: " + classe).PadRight(63, ' ') + "|");
                                        }
                                            
                                        Console.WriteLine("+--------------------------------------------------------------+");
                                        
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Não é possível examinar este item pois ele não está a seu alcance.");
                            }
                        }

                        if (comando.Equals(".up"))
                        {
                            int pontosAtrib = 0;
                            int pfor = 0;
                            int pint = 0;
                            int pvit = 0;
                            int pcom = 0;
                            int pagi = 0;
                            int pdes = 0;
                            int pres = 0;
                            int pcon = 0;
                            int pnivel = 0;

                            OdbcDataReader atrib = DbUtilities.doSelect("tb_personagem", "", "", "*", "id_personagem = " + idPersonagem);
                            if (atrib.Read())
                            {
                                pontosAtrib = Convert.ToInt32(atrib["nr_pontos_atributo"]);
                                pfor = Convert.ToInt32(atrib["nr_ataque"]);
                                pint = Convert.ToInt32(atrib["nr_inteligencia"]);
                                pvit = Convert.ToInt32(atrib["nr_vitalidade"]);
                                pcom = Convert.ToInt32(atrib["nr_composicao"]);
                                pagi = Convert.ToInt32(atrib["nr_agilidade"]);
                                pdes = Convert.ToInt32(atrib["nr_destreza"]);
                                pres = Convert.ToInt32(atrib["nr_defesa"]);
                                pcon = Convert.ToInt32(atrib["nr_concentracao"]);
                                pnivel = Convert.ToInt32(atrib["nr_nivel"]);
                            }

                            Console.Write("Quantos pontos deseja distribuir?: ");
                            string pontosDist = Console.ReadLine();

                            try
                            {
                                if (Convert.ToInt32(pontosDist) <= pontosAtrib)
                                {
                                    Console.Write("Qual atributo deseja avançar?[for/int/vit/com/agi/des/res/con]: ");
                                    comando = Console.ReadLine();

                                    int valida = 0;
                                    switch (comando)
                                    {
                                        case "for":
                                            valida = pfor;
                                            break;
                                        case "int":
                                            valida = pint;
                                            break;
                                        case "vit":
                                            valida = pvit;
                                            break;
                                        case "com":
                                            valida = pcom;
                                            break;
                                        case "agi":
                                            valida = pagi;
                                            break;
                                        case "des":
                                            valida = pdes;
                                            break;
                                        case "res":
                                            valida = pres;
                                            break;
                                        case "con":
                                            valida = pcon;
                                            break;
                                    }

                                    int xval = ((pnivel - 1)*2) - (valida - 5);

                                    if (xval >= Convert.ToInt32(pontosDist))
                                    {
                                        if (comando.Equals("for"))
                                        {
                                            DbUtilities.doUpdate("tb_personagem", "nr_ataque = nr_ataque + " + pontosDist + ",nr_pontos_atributo = nr_pontos_atributo - " + pontosDist, "id_personagem = " + idPersonagem);
                                            Console.WriteLine("Você aumentou " + pontosDist + " ponto(s) de força.");
                                        }
                                        else
                                        {
                                            if (comando.Equals("res"))
                                            {
                                                DbUtilities.doUpdate("tb_personagem", "nr_defesa = nr_defesa + " + pontosDist + ",nr_pontos_atributo = nr_pontos_atributo - " + pontosDist, "id_personagem = " + idPersonagem);
                                                Console.WriteLine("Você aumentou " + pontosDist + " ponto(s) de resistencia.");
                                            }
                                            else
                                            {
                                                if (comando.Equals("agi"))
                                                {
                                                    DbUtilities.doUpdate("tb_personagem", "nr_agilidade = nr_agilidade + " + pontosDist + ",nr_pontos_atributo = nr_pontos_atributo - " + pontosDist, "id_personagem = " + idPersonagem);
                                                    Console.WriteLine("Você aumentou " + pontosDist + " ponto(s) de agilidade.");
                                                }
                                                else
                                                {
                                                    if (comando.Equals("des"))
                                                    {
                                                        DbUtilities.doUpdate("tb_personagem", "nr_destreza = nr_destreza + " + pontosDist + ",nr_pontos_atributo = nr_pontos_atributo - " + pontosDist, "id_personagem = " + idPersonagem);
                                                        Console.WriteLine("Você aumentou " + pontosDist + " ponto(s) de destreza.");
                                                    }
                                                    else
                                                    {
                                                        if (comando.Equals("int"))
                                                        {
                                                            DbUtilities.doUpdate("tb_personagem", "nr_inteligencia = nr_inteligencia + " + pontosDist + ",nr_pontos_atributo = nr_pontos_atributo - " + pontosDist, "id_personagem = " + idPersonagem);
                                                            Console.WriteLine("Você aumentou " + pontosDist + " ponto(s) de inteligencia.");
                                                        }
                                                        else
                                                        {
                                                            if (comando.Equals("vit"))
                                                            {
                                                                DbUtilities.doUpdate("tb_personagem", "nr_vitalidade = nr_vitalidade + " + pontosDist + ",nr_pontos_atributo = nr_pontos_atributo - " + pontosDist, "id_personagem = " + idPersonagem);

                                                                DbUtilities.doUpdate("tb_personagem", "nr_hp_max = (55 + ( nr_nivel * (nr_vitalidade*2)))", "id_personagem = " + idPersonagem);

                                                                Console.WriteLine("Você aumentou " + pontosDist + " ponto(s) de vitalidade.");
                                                            }
                                                            else
                                                            {
                                                                if (comando.Equals("com"))
                                                                {
                                                                    DbUtilities.doUpdate("tb_personagem", "nr_composicao = nr_composicao + " + pontosDist + ",nr_pontos_atributo = nr_pontos_atributo - " + pontosDist, "id_personagem = " + idPersonagem);

                                                                    DbUtilities.doUpdate("tb_personagem", "nr_mp_max = (20 + ( nr_nivel * (nr_composicao * 2)))", "id_personagem = " + idPersonagem);

                                                                    Console.WriteLine("Você aumentou " + pontosDist + " ponto(s) de composição.");
                                                                }
                                                                else
                                                                {
                                                                    if (comando.Equals("con"))
                                                                    {
                                                                        DbUtilities.doUpdate("tb_personagem", "nr_concentracao = nr_concentracao + " + pontosDist + ",nr_pontos_atributo = nr_pontos_atributo - " + pontosDist, "id_personagem = " + idPersonagem);
                                                                        Console.WriteLine("Você aumentou " + pontosDist + " ponto(s) de concentração.");
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Este atributo não é válido.");
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (xval < 0)
                                            xval = 0;

                                        Console.WriteLine("Você não pode distribuir esta quantidade de pontos neste atributo. Quantidade possível: " + xval);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Quantidade inválida.");
                            }

                            
                        }

                        if (comando.Equals(".forja") || comando.Equals(".alquimia"))
                        {
                            string condicao = "";
                            Console.WriteLine("+--------------------------------------------------------------+");
                            if (comando.Equals(".forja"))
                            {
                                Console.WriteLine("| Itens disponíveis para forja                                 |");
                                condicao = "a.id_tipo = 'F' AND a.id_area = " + idAreaAtual;
                            }
                            else
                            {
                                Console.WriteLine("| Itens disponíveis para alguimia                              |");
                                condicao = "a.id_tipo = 'A' AND a.id_area = " + idAreaAtual;
                            }
                            Console.WriteLine("+--------------------------------------------------------------+");
                            OdbcDataReader forja = DbUtilities.doSelect("tb_forja","tb_item","a.id_item = b.id_item","*",condicao);
                            while (forja.Read())
                            {
                                Console.WriteLine(("| " + forja["tx_nome"].ToString()).PadRight(63,' ') + "|");
                            }
                            Console.WriteLine("+--------------------------------------------------------------+");
                            if (comando.Equals(".forja"))
                            {
                                Console.WriteLine("| Comando: .fj - Para forjar o item                            |");
                            }
                            else
                            {
                                Console.WriteLine("| Comando: .al - Para criar o item                             |");
                            }
                            Console.WriteLine("+--------------------------------------------------------------+");
                        }

                        if (comando.Equals(".fj") || comando.Equals(".al"))
                        {
                            string condicao = "";
                            int idItemForjei = 0;
                            string facilidade = "";
                            if (comando.Equals(".fj"))
                            {
                                Console.Write("Qual item deseja forjar?: ");
                                condicao = "a.id_tipo = 'F' AND a.id_area = " + idAreaAtual;
                            }
                            else
                            {
                                Console.Write("Qual item deseja criar?: ");
                                condicao = "a.id_tipo = 'A' AND a.id_area = " + idAreaAtual;
                            }

                            comando = Console.ReadLine();
                            OdbcDataReader fj = DbUtilities.doSelect("tb_forja", "tb_item", "a.id_item = b.id_item", "*", "b.tx_nome = '" + comando + "' AND " + condicao);
                            List<string[]> ingredientes = new List<string[]>();
                            if (fj.Read())
                            {
                                idItemForjei = Convert.ToInt32(fj["id_item"]);
                                facilidade = fj["tx_dificuldade"].ToString();
                                if (!fj["id_ingrediente1"].ToString().Equals("0"))
                                {
                                    string[] xf = new string[2] { fj["id_ingrediente1"].ToString(), fj["qt_ingrediente1"].ToString() };
                                    ingredientes.Add(xf);
                                }
                                if (!fj["id_ingrediente2"].ToString().Equals("0"))
                                {
                                    string[] xf = new string[2] { fj["id_ingrediente2"].ToString(), fj["qt_ingrediente2"].ToString() };
                                    ingredientes.Add(xf);
                                }
                                if (!fj["id_ingrediente3"].ToString().Equals("0"))
                                {
                                    string[] xf = new string[2] { fj["id_ingrediente3"].ToString(), fj["qt_ingrediente3"].ToString() };
                                    ingredientes.Add(xf);
                                }
                                if (!fj["id_ingrediente4"].ToString().Equals("0"))
                                {
                                    string[] xf = new string[2] { fj["id_ingrediente4"].ToString(), fj["qt_ingrediente4"].ToString() };
                                    ingredientes.Add(xf);
                                }
                                if (!fj["id_ingrediente5"].ToString().Equals("0"))
                                {
                                    string[] xf = new string[2] { fj["id_ingrediente5"].ToString(), fj["qt_ingrediente5"].ToString() };
                                    ingredientes.Add(xf);
                                }
                            }
                            else
                            {
                                Console.WriteLine(comando + ". Este item não está disponível para ser criado.");
                            }
                            bool temTudo = true;
                            foreach (string[] ing in ingredientes)
                            {
                                OdbcDataReader ingInv = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "a.id_personagem = " + idPersonagem + " AND a.id_item = " + ing[0]);
                                int contaIng = 0;
                                string oItem = "";
                                while (ingInv.Read())
                                {
                                    contaIng++;
                                }
                                OdbcDataReader itemVer = DbUtilities.doSelect("tb_item", "", "", "*", "id_item = " + ing[0]);
                                if (itemVer.Read())
                                {
                                    oItem = itemVer["tx_nome"].ToString();
                                }
                                if (contaIng < Convert.ToInt32(ing[1]))
                                {
                                    int mostra = Convert.ToInt32(ing[1]) - contaIng;
                                    temTudo = false;
                                    Console.WriteLine("Você precisa de mais " + mostra + "x " + oItem + " para realizar esta ação.");
                                }
                            }
                            if (temTudo)
                            {
                                Random rRan = new Random();
                                int deu = rRan.Next(0, 100000);
                                int lim = 0;
                                if (facilidade.Equals("F"))
                                    lim = 90000;
                                if (facilidade.Equals("M"))
                                    lim = 70000;
                                if (facilidade.Equals("D"))
                                    lim = 50000;

                                if (idItemForjei > 0)
                                {
                                    foreach (string[] ing in ingredientes)
                                    {
                                        for (int n = 0; n < Convert.ToInt32(ing[1]); n++)
                                        {
                                            DbUtilities.doQuery("DELETE FROM tb_inventario WHERE id_item = " + ing[0].ToString() + " AND id_personagem = " + idPersonagem + " LIMIT 1");
                                        }
                                    }
                                                                        
                                    if (deu <= lim)
                                    {
                                        DbUtilities.doInsert("tb_inventario", "id_personagem,id_item,tx_equipado", idPersonagem + "," + idItemForjei + ",''");
                                        if (comando.Equals(".fj"))
                                        {
                                            Console.WriteLine("Você forjou com sucesso " + comando + "!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Você criou com sucesso " + comando + "!");

                                        }
                                    }
                                    else
                                    {
                                        if (comando.Equals(".fj"))
                                        {
                                            Console.WriteLine("Infelizmente você não obteve sucesso ao tentar forjar " + comando);
                                        }
                                        else
                                        {
                                            Console.WriteLine("Infelizmente você não obteve sucesso ao tentar criar " + comando);
                                        }
                                        Console.WriteLine("Seus itens se quebraram no processo...");
                                    }
                                }

                            }
                        }

                        if (comando.Equals(".mapa"))
                        {
                            string nomeArea = "";
                            string descArea = "";
                            string idArea = "0";
                            string idAreaVinc = "0";
                            string osComandos = "";
                            Console.Write("Para qual direção? ");
                            comando = Console.ReadLine();
                            if (comando == "norte")
                            {
                                if (idNorte == 0)
                                {
                                    Console.Write("Nome da Area? ");
                                    nomeArea = Console.ReadLine();
                                    if (nomeArea == "existe")
                                    {
                                        Console.Write("ID da Area existente? ");
                                        idAreaVinc = Console.ReadLine();
                                        OdbcDataReader exist = DbUtilities.doSelect("tb_area", "", "", "id_sul", "id_area = " + idAreaVinc);
                                        if (exist.Read())
                                        {
                                            if (Convert.ToInt32(exist["id_sul"]) > 0)
                                            {
                                                Console.WriteLine("Essa area destino não pode ser utilizada");
                                            }
                                            else
                                            {
                                                DbUtilities.doUpdate("tb_area", "id_sul = " + idAreaAtual.ToString(), "id_area = " + idAreaVinc);
                                                DbUtilities.doUpdate("tb_area", "id_norte = " + idAreaVinc, "id_area = " + idAreaAtual.ToString());
                                                Console.WriteLine("Area vinculada como destino ao Norte");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Area não existe");
                                        }
                                    }
                                    else
                                    {
                                        Console.Write("Descrição da Area? ");
                                        descArea = Console.ReadLine();
                                        DbUtilities.doInsert("tb_area", "tx_nome,tx_descricao,id_norte,id_sul,id_leste,id_oeste,id_loja,id_estalagem,id_ferreiro,id_alquimista,id_deposito,tx_comandos", "'" + nomeArea + "','" + descArea + "',0," + idAreaAtual.ToString() + ",0,0,0,0,0,0,0,'.s'");
                                        OdbcDataReader area = DbUtilities.doSelect("tb_area", "", "", "id_area", "id_area > 0 ORDER BY id_area DESC");
                                        if (area.Read())
                                        {
                                            idArea = area["id_area"].ToString();
                                        }
                                        DbUtilities.doUpdate("tb_area", "id_norte = " + idArea, "id_area = " + idAreaAtual.ToString());
                                        Console.WriteLine("Você criou a Area " + nomeArea + " para o " + comando);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Já existe mapa nesta direção");
                                }
                            }
                            if (comando == "sul")
                            {
                                if (idSul == 0)
                                {
                                    Console.Write("Nome da Area? ");
                                    nomeArea = Console.ReadLine();
                                    if (nomeArea == "existe")
                                    {
                                        Console.Write("ID da Area existente? ");
                                        idAreaVinc = Console.ReadLine();
                                        OdbcDataReader exist = DbUtilities.doSelect("tb_area", "", "", "id_norte", "id_area = " + idAreaVinc);
                                        if (exist.Read())
                                        {
                                            if (Convert.ToInt32(exist["id_norte"]) > 0)
                                            {
                                                Console.WriteLine("Essa area destino não pode ser utilizada");
                                            }
                                            else
                                            {
                                                DbUtilities.doUpdate("tb_area", "id_norte = " + idAreaAtual.ToString(), "id_area = " + idAreaVinc);
                                                DbUtilities.doUpdate("tb_area", "id_sul = " + idAreaVinc, "id_area = " + idAreaAtual.ToString());
                                                Console.WriteLine("Area vinculada como destino ao Sul");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Area não existe");
                                        }
                                    }
                                    else
                                    {
                                        Console.Write("Descrição da Area? ");
                                        descArea = Console.ReadLine();
                                        DbUtilities.doInsert("tb_area", "tx_nome,tx_descricao,id_norte,id_sul,id_leste,id_oeste,id_loja,id_estalagem,id_ferreiro,id_alquimista,id_deposito,tx_comandos", "'" + nomeArea + "','" + descArea + "'," + idAreaAtual.ToString() + ",0,0,0,0,0,0,0,0,'.n'");
                                        OdbcDataReader area = DbUtilities.doSelect("tb_area", "", "", "id_area", "id_area > 0 ORDER BY id_area DESC");
                                        if (area.Read())
                                        {
                                            idArea = area["id_area"].ToString();
                                        }
                                        DbUtilities.doUpdate("tb_area", "id_sul = " + idArea, "id_area = " + idAreaAtual.ToString());
                                        Console.WriteLine("Você criou a Area " + nomeArea + " para o " + comando);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Já existe mapa nesta direção");
                                }
                            }
                            if (comando == "leste")
                            {
                                if (idLeste == 0)
                                {
                                    Console.Write("Nome da Area? ");
                                    nomeArea = Console.ReadLine();
                                    if (nomeArea == "existe")
                                    {
                                        Console.Write("ID da Area existente? ");
                                        idAreaVinc = Console.ReadLine();
                                        OdbcDataReader exist = DbUtilities.doSelect("tb_area", "", "", "id_oeste", "id_area = " + idAreaVinc);
                                        if (exist.Read())
                                        {
                                            if (Convert.ToInt32(exist["id_oeste"]) > 0)
                                            {
                                                Console.WriteLine("Essa area destino não pode ser utilizada");
                                            }
                                            else
                                            {
                                                DbUtilities.doUpdate("tb_area", "id_oeste = " + idAreaAtual.ToString(), "id_area = " + idAreaVinc);
                                                DbUtilities.doUpdate("tb_area", "id_leste = " + idAreaVinc, "id_area = " + idAreaAtual.ToString());
                                                Console.WriteLine("Area vinculada como destino ao Leste");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Area não existe");
                                        }
                                    }
                                    else
                                    {
                                        Console.Write("Descrição da Area? ");
                                        descArea = Console.ReadLine();
                                        DbUtilities.doInsert("tb_area", "tx_nome,tx_descricao,id_norte,id_sul,id_leste,id_oeste,id_loja,id_estalagem,id_ferreiro,id_alquimista,id_deposito,tx_comandos", "'" + nomeArea + "','" + descArea + "',0,0,0," + idAreaAtual.ToString() + ",0,0,0,0,0,'.o'");
                                        OdbcDataReader area = DbUtilities.doSelect("tb_area", "", "", "id_area", "id_area > 0 ORDER BY id_area DESC");
                                        if (area.Read())
                                        {
                                            idArea = area["id_area"].ToString();
                                        }
                                        DbUtilities.doUpdate("tb_area", "id_leste = " + idArea, "id_area = " + idAreaAtual.ToString());
                                        Console.WriteLine("Você criou a Area " + nomeArea + " para o " + comando);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Já existe mapa nesta direção");
                                }
                            }
                            if (comando == "oeste")
                            {
                                if (idOeste == 0)
                                {
                                    Console.Write("Nome da Area? ");
                                    nomeArea = Console.ReadLine();
                                    if (nomeArea == "existe")
                                    {
                                        Console.Write("ID da Area existente? ");
                                        idAreaVinc = Console.ReadLine();
                                        OdbcDataReader exist = DbUtilities.doSelect("tb_area", "", "", "id_leste", "id_area = " + idAreaVinc);
                                        if (exist.Read())
                                        {
                                            if (Convert.ToInt32(exist["id_leste"]) > 0)
                                            {
                                                Console.WriteLine("Essa area destino não pode ser utilizada");
                                            }
                                            else
                                            {
                                                DbUtilities.doUpdate("tb_area", "id_leste = " + idAreaAtual.ToString(), "id_area = " + idAreaVinc);
                                                DbUtilities.doUpdate("tb_area", "id_oeste = " + idAreaVinc, "id_area = " + idAreaAtual.ToString());
                                                Console.WriteLine("Area vinculada como destino ao Oeste");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Area não existe");
                                        }
                                    }
                                    else
                                    {
                                        Console.Write("Descrição da Area? ");
                                        descArea = Console.ReadLine();
                                        DbUtilities.doInsert("tb_area", "tx_nome,tx_descricao,id_norte,id_sul,id_leste,id_oeste,id_loja,id_estalagem,id_ferreiro,id_alquimista,id_deposito,tx_comandos", "'" + nomeArea + "','" + descArea + "',0,0," + idAreaAtual.ToString() + ",0,0,0,0,0,0,'.l'");
                                        OdbcDataReader area = DbUtilities.doSelect("tb_area", "", "", "id_area", "id_area > 0 ORDER BY id_area DESC");
                                        if (area.Read())
                                        {
                                            idArea = area["id_area"].ToString();
                                        }
                                        DbUtilities.doUpdate("tb_area", "id_oeste = " + idArea, "id_area = " + idAreaAtual.ToString());
                                        Console.WriteLine("Você criou a Area " + nomeArea + " para o " + comando);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Já existe mapa nesta direção");
                                }
                            }
                            OdbcDataReader aA = DbUtilities.doSelect("tb_area", "", "", "*", "id_area = " + idAreaAtual.ToString());
                            if (aA.Read())
                            {
                                if (Convert.ToInt32(aA["id_norte"]) > 0)
                                {
                                    osComandos += ".n";
                                }
                                if (Convert.ToInt32(aA["id_sul"]) > 0)
                                {
                                    if (osComandos.Length > 0)
                                    {
                                        osComandos += "/";
                                    }
                                    osComandos += ".s";
                                }
                                if (Convert.ToInt32(aA["id_leste"]) > 0)
                                {
                                    if (osComandos.Length > 0)
                                    {
                                        osComandos += "/";
                                    }
                                    osComandos += ".l";
                                }
                                if (Convert.ToInt32(aA["id_oeste"]) > 0)
                                {
                                    if (osComandos.Length > 0)
                                    {
                                        osComandos += "/";
                                    }
                                    osComandos += ".o";
                                }
                                if (Convert.ToInt32(aA["id_loja"]) > 0)
                                {
                                    if (osComandos.Length > 0)
                                    {
                                        osComandos += "/";
                                    }
                                    osComandos += ".lj";
                                }
                                if (Convert.ToInt32(aA["id_ferreiro"]) > 0)
                                {
                                    if (osComandos.Length > 0)
                                    {
                                        osComandos += "/";
                                    }
                                    osComandos += ".fe";
                                }
                                if (Convert.ToInt32(aA["id_alquimista"]) > 0)
                                {
                                    if (osComandos.Length > 0)
                                    {
                                        osComandos += "/";
                                    }
                                    osComandos += ".t";
                                }
                                if (Convert.ToInt32(aA["id_estalagem"]) > 0)
                                {
                                    if (osComandos.Length > 0)
                                    {
                                        osComandos += "/";
                                    }
                                    osComandos += ".e";
                                }
                                if (Convert.ToInt32(aA["id_deposito"]) > 0)
                                {
                                    if (osComandos.Length > 0)
                                    {
                                        osComandos += "/";
                                    }
                                    osComandos += ".d";
                                }
                                DbUtilities.doUpdate("tb_area", "tx_comandos = '" + osComandos + "'", "id_area = " + idAreaAtual.ToString());
                            }
                            osComandos = "";
                            if (Convert.ToInt32(idAreaVinc) > 0)
                            {
                                OdbcDataReader aB = DbUtilities.doSelect("tb_area", "", "", "*", "id_area = " + idAreaVinc);
                                if (aB.Read())
                                {
                                    if (Convert.ToInt32(aB["id_norte"]) > 0)
                                    {
                                        osComandos += ".n";
                                    }
                                    if (Convert.ToInt32(aB["id_sul"]) > 0)
                                    {
                                        if (osComandos.Length > 0)
                                        {
                                            osComandos += "/";
                                        }
                                        osComandos += ".s";
                                    }
                                    if (Convert.ToInt32(aB["id_leste"]) > 0)
                                    {
                                        if (osComandos.Length > 0)
                                        {
                                            osComandos += "/";
                                        }
                                        osComandos += ".l";
                                    }
                                    if (Convert.ToInt32(aB["id_oeste"]) > 0)
                                    {
                                        if (osComandos.Length > 0)
                                        {
                                            osComandos += "/";
                                        }
                                        osComandos += ".o";
                                    }
                                    if (Convert.ToInt32(aB["id_loja"]) > 0)
                                    {
                                        if (osComandos.Length > 0)
                                        {
                                            osComandos += "/";
                                        }
                                        osComandos += ".lj";
                                    }
                                    if (Convert.ToInt32(aB["id_ferreiro"]) > 0)
                                    {
                                        if (osComandos.Length > 0)
                                        {
                                            osComandos += "/";
                                        }
                                        osComandos += ".fe";
                                    }
                                    if (Convert.ToInt32(aB["id_alquimista"]) > 0)
                                    {
                                        if (osComandos.Length > 0)
                                        {
                                            osComandos += "/";
                                        }
                                        osComandos += ".t";
                                    }
                                    if (Convert.ToInt32(aB["id_estalagem"]) > 0)
                                    {
                                        if (osComandos.Length > 0)
                                        {
                                            osComandos += "/";
                                        }
                                        osComandos += ".e";
                                    }
                                    if (Convert.ToInt32(aB["id_deposito"]) > 0)
                                    {
                                        if (osComandos.Length > 0)
                                        {
                                            osComandos += "/";
                                        }
                                        osComandos += ".d";
                                    }
                                    DbUtilities.doUpdate("tb_area", "tx_comandos = '" + osComandos + "'", "id_area = " + idAreaVinc);
                                }
                            }
                        }

                        if (comando.Equals(".resp"))
                        {
                            int idCriatura = 0;
                            int nrQuant = 0;
                            string txNome = "";
                            
                            Console.Write("Qual criatura? ");
                            comando = Console.ReadLine();
                            OdbcDataReader cria = DbUtilities.doSelect("tb_criatura", "", "", "*", "tx_nome like '%" + comando + "%'");
                            if (cria.Read())
                            {
                                idCriatura = Convert.ToInt32(cria["id_criatura"]);
                                txNome = cria["tx_nome"].ToString();
                            }
                            if (idCriatura > 0)
                            {
                                Console.Write("Quantos " + txNome + "? ");
                                comando = Console.ReadLine();
                                nrQuant = Convert.ToInt32(comando);
                                if (nrQuant > 0)
                                {
                                    Console.Write("Tempo? ");
                                    comando = Console.ReadLine();
                                    DbUtilities.doInsert("tb_respaw", "id_area,id_criatura,qt_maximo,qt_atual,vl_tempo", idAreaAtual + "," + idCriatura + "," + nrQuant + "," + nrQuant + "," + comando);
                                    Console.WriteLine("Você criou o respaw de " + txNome + "!");
                                }                                
                            }
                            else
                            {
                                Console.WriteLine("Criatura não existe.");
                            }
                        }
                        if (comando.Equals(".criar"))
                        {
                            int idItem = 0;
                            Console.WriteLine("Qual item deseja criar?");
                            comando = Console.ReadLine();
                            OdbcDataReader cria = DbUtilities.doSelect("tb_item", "", "", "*", "tx_nome = '" + comando + "'");
                            if (cria.Read())
                            {
                                idItem = Convert.ToInt32(cria["id_item"]);
                            }
                            if (idItem > 0)
                            {
                                DbUtilities.doInsert("tb_inventario", "id_personagem,id_item,tx_equipado", idPersonagem + "," + idItem + ",''");
                                Console.WriteLine("Você criou o item " + comando + "!");
                            }
                            else
                            {
                                Console.WriteLine("Esse item não existe.");
                            }
                        }
                        if (comando.Equals(".v"))
                        {
                            int nconta = 0;
                            OdbcDataReader reader = DbUtilities.doSelect("tb_personagem", "tb_area", "a.id_area = b.id_area", "b.id_area, b.tx_descricao", "a.id_personagem = " + idPersonagem);
                            if (reader.Read())
                            {
                                Console.WriteLine("---------------------------Descrição do Local--------------------------");
                                Console.WriteLine(reader["id_area"].ToString() + " " + reader["tx_descricao"].ToString());
                            }
                            OdbcDataReader itens = DbUtilities.doSelect("tb_item_area", "tb_item", "a.id_item = b.id_item", "*", "id_area = " + idAreaAtual);
                            while (itens.Read())
                            {
                                if (nconta == 0)
                                    Console.WriteLine("---------------------------Itens neste local---------------------------");
                                nconta++;
                                Console.Write(itens["tx_nome"].ToString() + ", ");
                                Console.WriteLine();
                            }
                                                    
                            OdbcDataReader resp = DbUtilities.doSelect("tb_respaw", "tb_criatura", "a.id_criatura = b.id_criatura", "*", "id_area = " + idAreaAtual + " AND a.qt_atual > 0");
                            nconta = 0;
                            while (resp.Read())
                            {
                                if (nconta == 0)
                                    Console.WriteLine("-------------------------Criaturas neste local-------------------------");
                                nconta++;
                                for (int i = 0; i < Convert.ToInt32(resp["qt_atual"]); i++)
                                {
                                    Console.Write(resp["tx_nome"].ToString() + ", ");
                                }
                                Console.WriteLine();
                            }
                            OdbcDataReader npc = DbUtilities.doSelect("tb_npc", "", "", "*", "id_area = " + idAreaAtual);
                            nconta = 0;
                            while (npc.Read())
                            {
                                if (nconta==0)
                                    Console.WriteLine("---------------------------NPCs neste local----------------------------");
                                nconta++;
                                Console.Write("!" + npc["tx_nome"].ToString());
                                Console.WriteLine();
                            }
                                                        
                            OdbcDataReader plays = DbUtilities.doSelect("tb_personagem", "", "", "*", "id_area = " + idAreaAtual + " AND id_personagem != " + idPersonagem);
                            nconta = 0;
                            while (plays.Read())
                            {
                                if (nconta==0)
                                    Console.WriteLine("--------------------------Players neste local-------------------------- ");
                                nconta++;
                                Console.Write(plays["tx_nome"].ToString() + ", ");
                                Console.WriteLine();
                            }
                            Console.WriteLine("-----------------------------------------------------------------------");
                        }

                        if (comando.Equals(".quest"))
                        {
                            Console.WriteLine();
                            Console.WriteLine("+++++++++++++++++++++++++ Quadro de Missões +++++++++++++++++++++++++");
                            OdbcDataReader quest = DbUtilities.doSelect("tb_quest_personagem", "tb_etapa_quest", "a.id_etapa_quest = b.id_etapa_quest", "b.id_tipo,b.tx_nome,b.tx_descricao,a.nr_contador as conta, b.nr_contador as total", "a.id_personagem = " + idPersonagem + " AND st_situacao != 'O'");
                            while (quest.Read())
                            {
                                Console.WriteLine(quest["tx_nome"]);
                                Console.Write("> " + quest["tx_descricao"]);
                                if (quest["id_tipo"].ToString().Equals("H"))
                                {
                                    Console.Write(" [" + quest["conta"].ToString() + "/" + quest["total"].ToString() + "]");
                                }
                                Console.WriteLine();
                            }
                        }

                        if (comando.Length > 0)
                        {
                            if (comando.Substring(0, 1).Equals("!"))
                            {
                                int idNpc = 0;
                                string nome = "";
                                string mensagem = "";
                                OdbcDataReader npc = DbUtilities.doSelect("tb_npc", "tb_acao_npc", "a.id_npc = b.id_npc", "*", "a.id_area = " + idAreaAtual + " AND b.tx_comando = '" + comando + "'");
                                int idQuest = 0;
                                if (npc.Read())
                                {
                                    idNpc = Convert.ToInt32(npc["id_npc"]);
                                    nome = npc["tx_nome"].ToString();
                                    mensagem = npc["tx_resposta"].ToString();
                                    idQuest = Convert.ToInt32(npc["id_quest"]);
                                }
                                else
                                {
                                    Console.WriteLine("Nenhum NPC que responda por este comando neste local.");
                                }

                                if (idQuest > 0)
                                {
                                    bool completa = false;
                                    int idQuestPer = 0;
                                    int idItemTemQTer = 0;
                                    OdbcDataReader qst = DbUtilities.doSelect("tb_quest_personagem", "tb_etapa_quest", "a.id_etapa_quest = b.id_etapa_quest", "*", "a.id_personagem = " + idPersonagem + " AND a.id_quest = " + idQuest);
                                    if (qst.Read())
                                    {
                                        if (qst["st_situacao"].ToString().Equals("O"))
                                        {
                                            mensagem = "Sim sim.. Bom trabalho...";
                                        }
                                        else
                                        {
                                            if (qst["st_situacao"].ToString().Equals("X"))
                                            {
                                                mensagem = "Parabéns, aqui está sua recompensa!";
                                                completa = true;
                                                idQuestPer = Convert.ToInt32(qst["id_quest_personagem"]);
                                            }
                                            else
                                            {
                                                if (qst["id_tipo"].Equals("I"))
                                                {
                                                    idItemTemQTer = Convert.ToInt32(qst["id_item"]);
                                                    mensagem = qst["tx_descricao"].ToString();
                                                    idQuestPer = Convert.ToInt32(qst["id_quest_personagem"]);
                                                }
                                                else
                                                {
                                                    mensagem = "Você ainda não concluiu a missão..." + qst["tx_descricao"].ToString();
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        int idEtapa = 0;
                                        OdbcDataReader etp = DbUtilities.doSelect("tb_quest", "", "", "*", "id_quest = " + idQuest);
                                        if (etp.Read())
                                        {
                                            idEtapa = Convert.ToInt32(etp["id_primeira"]);
                                        }
                                        DbUtilities.doInsert("tb_quest_personagem", "id_personagem,id_quest,id_etapa_quest,nr_contador,st_conversou,st_situacao", idPersonagem + "," + idQuest + "," + idEtapa + ",0,'',''");
                                        Console.WriteLine("Seu quadro de missões foi atualizado.");
                                    }

                                    
                                    if (idItemTemQTer > 0)
                                    {
                                        int idInvDeleta = 0;
                                        string nmitem = "";

                                        OdbcDataReader inv = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "a.id_item = " + idItemTemQTer + " AND a.id_personagem = " + idPersonagem);
                                        if (inv.Read())
                                        {
                                            idInvDeleta = Convert.ToInt32(inv["id_inventario"]);
                                            nmitem = inv["tx_nome"].ToString();
                                        }
                                        else
                                        {
                                            mensagem = "Você ainda não concluiu a missão..." + mensagem;
                                        }
                                        if (idInvDeleta > 0)
                                        {
                                            DbUtilities.doQuery("DELETE FROM tb_inventario WHERE id_inventario = " + idInvDeleta);
                                            Console.WriteLine("Você entregou " + nmitem + ".");
                                            mensagem = "Parabéns, aqui está sua recompensa!";
                                            completa = true;
                                            DbUtilities.doUpdate("tb_quest_personagem", "st_situacao = 'O'", "id_quest_personagem = " + idQuestPer);
                                        }
                                    }

                                    if (completa)
                                    {
                                        OdbcDataReader aquest = DbUtilities.doSelect("tb_quest", "", "", "*", "id_quest = " + idQuest);

                                        int idItemGanho = 0;
                                        int expGanho = 0;
                                        int goldGanho = 0;

                                        if (aquest.Read())
                                        {
                                            idItemGanho = Convert.ToInt32(aquest["id_item"]);
                                            expGanho = Convert.ToInt32(aquest["nr_exp"]);
                                            goldGanho = Convert.ToInt32(aquest["nr_gold"]);
                                        }

                                        bool segue = true;
                                        if (idItemGanho > 0)
                                        {
                                            OdbcDataReader inventario = DbUtilities.doSelect("tb_inventario", "", "", "*", "id_personagem = " + idPersonagem);
                                            int contar = 0;
                                            while (inventario.Read())
                                            {
                                                contar++;
                                            }
                                            if (contar == maximaCarga)
                                            {
                                                segue = false;
                                                Console.WriteLine("Você não possui espaço para carregar mais itens. Arrume espaço e volte aqui para buscar sua recompensa...");
                                            }
                                            else
                                            {
                                                OdbcDataReader ite = DbUtilities.doSelect("tb_item", "", "", "*", "id_item = " + idItemGanho);
                                                if (ite.Read())
                                                {
                                                    Console.WriteLine("Você ganhou um(a) " + ite["tx_nome"].ToString());
                                                }
                                                DbUtilities.doInsert("tb_inventario", "id_personagem,id_item,tx_equipado", idPersonagem + "," + idItemGanho + ",''");
                                            }
                                        }

                                        if (segue)
                                        {
                                            if (goldGanho > 0)
                                            {
                                                DbUtilities.doUpdate("tb_personagem", "nr_ouro = nr_ouro + " + goldGanho, "id_personagem = " + idPersonagem);
                                                Console.WriteLine("Você ganhou " + goldGanho + " moedas de ouro.");
                                            }

                                            if (expGanho > 0)
                                            {
                                                int nivelAtual = 0;
                                                int expAtual = 0;
                                                int expNecessario = 0;
                                                OdbcDataReader p = DbUtilities.doSelect("tb_personagem", "", "", "*", "id_personagem = " + idPersonagem);
                                                if (p.Read())
                                                {
                                                    nivelAtual = Convert.ToInt32(p["nr_nivel"]);
                                                    expAtual = Convert.ToInt32(p["nr_exp"]);
                                                    expNecessario = Convert.ToInt32(p["nr_exp_next"]);
                                                }

                                                Console.WriteLine("Você ganhou " + expGanho + " pontos de experiência.");
                                                if (expAtual + expGanho >= expNecessario)
                                                {
                                                    nivelAtual++;
                                                    int ExpNext = Convert.ToInt32(Math.Round((80.000000000 / 3) * Math.Pow(nivelAtual, 3) - (80 * Math.Pow(nivelAtual, 2)) + ((850.000000000 / 3) * nivelAtual - 210)));
                                                    Console.WriteLine("########## Você avançou do nível " + (nivelAtual - 1).ToString() + " para o nível " + nivelAtual + "! ##########");
                                                    DbUtilities.doUpdate("tb_personagem", "nr_exp = nr_exp + " + expGanho + ",nr_pontos_atributo = nr_pontos_atributo + 6, nr_exp_next = " + ExpNext + ", nr_nivel = " + nivelAtual + ", nr_hp_max = (55 + ( " + nivelAtual + " * (nr_vitalidade*2))), nr_hp = nr_hp_max, nr_mp_max = (20 + (" + nivelAtual + " * (nr_composicao * 2))),nr_mp = nr_mp_max", "id_personagem = " + idPersonagem);
                                                }
                                                else
                                                {
                                                    DbUtilities.doUpdate("tb_personagem", "nr_exp = nr_exp + " + expGanho, "id_personagem = " + idPersonagem);
                                                }

                                            }

                                            DbUtilities.doUpdate("tb_quest_personagem", "st_situacao = 'O'", "id_quest_personagem = " + idQuestPer);
                                        }
                                    }
                                }
                                if (idNpc > 0)
                                {
                                    Console.WriteLine(nome + ": " + mensagem);
                                    OdbcDataReader vQ = DbUtilities.doSelect("tb_quest_personagem", "tb_etapa_quest", "a.id_etapa_quest = b.id_etapa_quest", "*", "b.id_tipo = 'C' AND b.id_npc = " + idNpc + " AND a.id_personagem = " + idPersonagem);
                                    int idQp = 0;
                                    if (vQ.Read())
                                    {
                                        idQp = Convert.ToInt32(vQ["id_quest_personagem"]);
                                    }
                                    if (idQp > 0)
                                    {
                                        DbUtilities.doUpdate("tb_quest_personagem", "st_situacao = 'X'", "id_quest_personagem = " + idQp);
                                        //Console.WriteLine("Seu quadro de missões foi atualizado.");
                                    }
                                }
                            }
                        }

                        if (comando.Equals(".buscar"))
                        {
                            Console.WriteLine("+---------------------Itens no seu depósito--------------------+");
                            OdbcDataReader depot = DbUtilities.doSelect("tb_deposito", "tb_item", "a.id_item = b.id_item", "b.tx_nome, COUNT(*) qt", "a.id_personagem = " + idPersonagem + " AND a.id_area = " + idAreaAtual + " GROUP BY b.tx_nome ORDER BY b.tx_nome");
                            while (depot.Read())
                            {
                                Console.WriteLine(("| " + depot["qt"].ToString() + "x " + depot["tx_nome"].ToString()).PadRight(63, ' ') + "|");
                            }
                            Console.WriteLine("+--------------------------------------------------------------+");
                        }

                        if (comando.Equals(".pegar"))
                        {
                            OdbcDataReader inventario = DbUtilities.doSelect("tb_inventario", "", "", "*", "id_personagem = " + idPersonagem);
                            int contar = 0;
                            while (inventario.Read())
                            {
                                contar++;
                            }
                            if (contar == maximaCarga)
                            {
                                Console.WriteLine("Você não possui espaço para carregar mais itens.");
                            }
                            else
                            {
                                Console.Write("O que deseja pegar do seu depósito?: ");
                                comando = Console.ReadLine();
                                int idDep = 0;
                                int idItemDep = 0;
                                OdbcDataReader depot = DbUtilities.doSelect("tb_deposito", "tb_item", "a.id_item = b.id_item", "*", "a.id_personagem = " + idPersonagem + " AND a.id_area = " + idAreaAtual + " AND b.tx_nome = '" + comando + "'");
                                if (depot.Read())
                                {
                                    idDep = Convert.ToInt32(depot["id_deposito"]);
                                    idItemDep = Convert.ToInt32(depot["id_item"]);
                                }
                                else
                                {
                                    Console.WriteLine("Você não possui " + comando + " no seu depósito.");
                                }

                                if (idDep > 0)
                                {
                                    DbUtilities.doQuery("DELETE FROM tb_deposito WHERE id_deposito = " + idDep);
                                    DbUtilities.doInsert("tb_inventario", "id_personagem,id_item,tx_equipado", idPersonagem + "," + idItemDep + ",''");
                                    Console.WriteLine("Você pegou " + comando + " do seu depósito.");
                                }
                            }
                        }

                        if (comando.Equals(".guardar"))
                        {
                            Console.Write("O que deseja guardar no seu depósito?: ");
                            comando = Console.ReadLine();
                            OdbcDataReader inv = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "b.tx_nome = '" + comando + "' AND id_personagem = " + idPersonagem);
                            string idInventario = "";
                            string idItem = "";
                            if (inv.Read())
                            {
                                idItem = inv["id_item"].ToString();
                                idInventario = inv["id_inventario"].ToString();
                            }

                            if (!idInventario.Equals(""))
                            {
                                DbUtilities.doInsert("tb_deposito", "id_personagem,id_item,id_area",idPersonagem + "," + idItem + "," + idAreaAtual);
                                DbUtilities.doQuery("DELETE FROM tb_inventario WHERE id_inventario = " + idInventario);
                                Console.WriteLine("Você guardou " + comando + " no seu depósito.");
                            }
                        }

                        if (comando.Equals(".drop"))
                        {
                            Console.Write("O que deseja descartar?: ");
                            comando = Console.ReadLine();
                            OdbcDataReader inv = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "b.tx_nome like '%" + comando + "%' AND id_personagem = " + idPersonagem);
                            string idInventario = "";
                            string idItem = "";
                            string txNome = "";
                            if (inv.Read())
                            {
                                idItem = inv["id_item"].ToString();
                                idInventario = inv["id_inventario"].ToString();
                                txNome = inv["tx_nome"].ToString();
                            }

                            if (!idInventario.Equals(""))
                            {
                                DbUtilities.doInsert("tb_item_area", "id_item,id_area", idItem + "," + idAreaAtual);
                                DbUtilities.doQuery("DELETE FROM tb_inventario WHERE id_inventario = " + idInventario);
                                Console.WriteLine("Você descartou " + txNome);
                            }
                        }

                        if (comando.Equals(".get"))
                        {
                            OdbcDataReader inventario = DbUtilities.doSelect("tb_inventario", "", "", "*", "id_personagem = " + idPersonagem);
                            int contar = 0;
                            while (inventario.Read())
                            {
                                contar++;
                            }
                            if (contar == maximaCarga)
                            {
                                Console.WriteLine("Você não possui espaço para carregar mais itens.");
                            }
                            else
                            {
                                Console.Write("O que deseja pegar?: ");
                                comando = Console.ReadLine();
                                if (!comando.Equals(String.Empty))
                                {
                                    OdbcDataReader chao = DbUtilities.doSelect("tb_item_area", "tb_item", "a.id_item = b.id_item", "*", "b.tx_nome like '%" + comando + "%' AND a.id_area = " + idAreaAtual);
                                    string idItem = "";
                                    string idChao = "";
                                    string txNome = "";
                                    if (chao.Read())
                                    {
                                        idItem = chao["id_item"].ToString();
                                        idChao = chao["id_item_area"].ToString();
                                        txNome = chao["tx_nome"].ToString();
                                    }
                                    if (!idChao.Equals(""))
                                    {
                                        DbUtilities.doInsert("tb_inventario", "id_personagem,id_item,tx_equipado", idPersonagem + "," + idItem + ",'   '");
                                        DbUtilities.doQuery("DELETE FROM tb_item_area WHERE id_item_area = " + idChao);
                                        Console.WriteLine("Você pegou " + txNome);
                                    }
                                }
                            }
                        }

                        if (comando.Equals(".u"))
                        {
                            int idInvUsar = 0;
                            int idItemqueusa = 0;
                            Console.Write("O que deseja usar?: ");
                            comando = Console.ReadLine();

                            OdbcDataReader inv = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "a.id_personagem = " + idPersonagem + " AND b.id_tipo = 'I' AND b.tx_nome = '" + comando + "'");
                            if (inv.Read())
                            {
                                idItemqueusa = Convert.ToInt32(inv["id_item"]);
                                idInvUsar = Convert.ToInt32(inv["id_inventario"]);
                            }
                            else
                            {
                                Console.WriteLine("Você não possui " + comando + ". Ou este não é um item que pode ser consumido.");
                            }

                            if (idInvUsar > 0)
                            {
                                OdbcDataReader efeito = DbUtilities.doSelect("tb_efeito_item", "", "", "*", "id_item = " + idItemqueusa);
                                string tipoEfeito = "";
                                int varia = 0;
                                int contaefeito = 0;
                                if (efeito.Read())
                                {
                                    tipoEfeito = efeito["id_tipoefeito"].ToString();
                                    varia = Convert.ToInt32(efeito["nr_variavel"]);
                                    contaefeito = Convert.ToInt32(efeito["nr_contaefeito"]);
                                }
                                if (tipoEfeito.Equals("H"))
                                {
                                    int hpmax = 0;
                                    OdbcDataReader perso = DbUtilities.doSelect("tb_personagem", "", "", "*", "id_personagem = " + idPersonagem);
                                    if (perso.Read())
                                    {
                                        hpmax = Convert.ToInt32(perso["nr_hp_max"]);
                                    }

                                    hpmax = (hpmax * varia) / 100;

                                    DbUtilities.doUpdate("tb_personagem", "nr_hp = nr_hp + " + hpmax, "id_personagem = " + idPersonagem + " AND nr_hp + " + hpmax + " < nr_hp_max");
                                    DbUtilities.doUpdate("tb_personagem", "nr_hp = nr_hp_max", "id_personagem = " + idPersonagem + " AND nr_hp + " + hpmax + " >= nr_hp_max");
                                    Console.WriteLine("Você recuperou " + hpmax + " pontos de energia.");
                                }
                                else
                                {
                                    if (tipoEfeito.Equals("M"))
                                    {
                                        int mpmax = 0;
                                        OdbcDataReader perso = DbUtilities.doSelect("tb_personagem", "", "", "*", "id_personagem = " + idPersonagem);
                                        if (perso.Read())
                                        {
                                            mpmax = Convert.ToInt32(perso["nr_mp_max"]);
                                        }

                                        mpmax = (mpmax * varia) / 100;

                                        DbUtilities.doUpdate("tb_personagem", "nr_mp = nr_mp + " + mpmax, "id_personagem = " + idPersonagem + " AND nr_mp + " + mpmax + " < nr_mp_max");
                                        DbUtilities.doUpdate("tb_personagem", "nr_mp = nr_mp_max", "id_personagem = " + idPersonagem + " AND nr_mp + " + mpmax + " >= nr_mp_max");
                                        Console.WriteLine("Você recuperou " + mpmax + " pontos de mana.");
                                    }
                                    else
                                    {
                                        DbUtilities.doUpdate("tb_personagem", "id_tipoefeito = '" + tipoEfeito + "', nr_variavel = " + varia + ", nr_contaefeito = " + contaefeito, "id_personagem = " + idPersonagem);
                                        Console.WriteLine("Você usou " + comando + " e já pode sentir seu efeito...");
                                    }
                                }
                                

                                DbUtilities.doInsert("tb_inventario", "id_personagem,id_item,tx_equipado", idPersonagem + ",24,''");
                                DbUtilities.doQuery("DELETE FROM tb_inventario WHERE id_inventario = " + idInvUsar);
                            }
                        }

                        if (comando.Equals(".deq"))
                        {
                            int idInvEquipar = 0; 

                            Console.Write("O que deseja desequipar?: ");
                            comando = Console.ReadLine();
                            string txNome = "";
                            if (!comando.Equals(string.Empty))
                            {
                                OdbcDataReader inv = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "a.id_personagem = " + idPersonagem + " AND a.tx_equipado != '' AND b.tx_nome like '%" + comando + "%'");
                                if (inv.Read())
                                {
                                    idInvEquipar = Convert.ToInt32(inv["id_inventario"]);
                                    txNome = inv["tx_nome"].ToString();
                                }
                                else
                                {
                                    Console.WriteLine("Você não está com " + txNome + " equipado(a).");
                                }
                            }
                            if (idInvEquipar > 0)
                            {
                                DbUtilities.doUpdate("tb_inventario", "tx_equipado = ''", "id_inventario = " + idInvEquipar);
                                Console.WriteLine("Você desequipou " + txNome);
                            }
                        }

                        if (comando.Equals(".eq"))
                        {
                            int nivelAtu = 0;
                            OdbcDataReader readplay = DbUtilities.doSelect("tb_personagem", "", "", "*", "id_personagem = " + idPersonagem);
                            if (readplay.Read())
                            {
                                nivelAtu = Convert.ToInt32(readplay["nr_nivel"]);
                            }

                            string posEquip = "";
                            int idInvEquipar = 0;
                            int nivelItem = 0;
                            string txNome = "";
                            Console.Write("O que deseja equipar?: ");
                            comando = Console.ReadLine();
                            if (!comando.Equals(String.Empty))
                            {
                                OdbcDataReader inv = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "a.id_personagem = " + idPersonagem + " AND b.tx_nome like '%" + comando + "%'");
                                if (inv.Read())
                                {
                                    idInvEquipar = Convert.ToInt32(inv["id_inventario"]);
                                    nivelItem = Convert.ToInt32(inv["nr_nivel"]);
                                    txNome = inv["tx_nome"].ToString();

                                    if (inv["id_tipo"].ToString().Equals("C"))
                                    {
                                        posEquip = "[1]";
                                    }
                                    if (inv["id_tipo"].ToString().Equals("W"))
                                    {
                                        posEquip = "[2]";
                                    }
                                    if (inv["id_tipo"].ToString().Equals("E"))
                                    {
                                        posEquip = "[3]";
                                    }
                                    if (inv["id_tipo"].ToString().Equals("A"))
                                    {
                                        posEquip = "[4]";
                                    }
                                    if (inv["id_tipo"].ToString().Equals("B"))
                                    {
                                        posEquip = "[5]";
                                    }
                                    if (inv["id_tipo"].ToString().Equals("D"))
                                    {
                                        posEquip = "[2][3]";
                                    }
                                    if (inv["id_tipo"].ToString().Equals("I"))
                                    {
                                        Console.WriteLine(txNome + " não pode ser equipado(a).");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Você não possui " + txNome + " para equipar.");
                                }

                                if (nivelItem > nivelAtu)
                                {
                                    Console.WriteLine("Você precisa estar no nível " + nivelItem + " para equipar " + txNome);
                                    posEquip = "";
                                }

                                if (!posEquip.Equals(""))
                                {
                                    int idInventario = 0;
                                    OdbcDataReader inv2 = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "a.id_personagem = " + idPersonagem + " AND a.tx_equipado LIKE '%" + posEquip + "%'");
                                    if (inv2.Read())
                                    {
                                        idInventario = Convert.ToInt32(inv2["id_inventario"]);
                                        Console.WriteLine("Você desequipou " + inv2["tx_nome"].ToString());
                                    }
                                    if (idInventario > 0)
                                    {
                                        DbUtilities.doUpdate("tb_inventario", "tx_equipado = ''", "id_inventario = " + idInventario);
                                    }
                                    if (posEquip.Equals("[2][3]"))
                                    {
                                        OdbcDataReader deseq = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "a.id_personagem = " + idPersonagem + " AND a.tx_equipado IN ('[2]','[3]')");
                                        List<string> ldeseq = new List<string>();
                                        while (deseq.Read())
                                        {
                                            Console.WriteLine("Você desequipou " + deseq["tx_nome"].ToString());
                                            ldeseq.Add(deseq["id_inventario"].ToString());
                                        }
                                        foreach (string dsq in ldeseq)
                                        {
                                            DbUtilities.doUpdate("tb_inventario", "tx_equipado = ''", "id_inventario = " + dsq);
                                        }
                                    }
                                    if (idInvEquipar > 0)
                                    {
                                        DbUtilities.doUpdate("tb_inventario", "tx_equipado = '" + posEquip + "'", "id_inventario = " + idInvEquipar);
                                        Console.WriteLine("Você equipou " + txNome);
                                    }
                                }
                            }
                        }

                        if (comando.Equals(".f"))
                        {
                            Console.Write("Com qual criatura deseja lutar?: ");
                            comando = Console.ReadLine();

                            int nivelAtual = 0;
                            int expAtual = 0;
                            int expNecessario = 0;
                            int ouroAtual = 0;
                            int modOuro = 0;
                            int modExp = 0;
                            int modLoot = 0;

                            int exp = 0;
                            int gold = 0;

                            int idResp = 0;
                            int qtAtual = 0;

                            int idMonstro = 0;
                            int hpMonstro = 0;
                            int atkMonstro = 0;
                            int defMonstro = 0;
                            int agiMonstro = 0;
                            int desMonstro = 0;

                            int hpPlay = 0;
                            int mpPlay = 0;
                            int atkPlay = 0;
                            int defPlay = 0;
                            int agiPlay = 0;
                            int desPlay = 0;
                            int intPlay = 0;
                            int conPlay = 0;

                            string nmMonstro = "";
                            string nmPlay = "";
                            string txNome = "";

                            OdbcDataReader spaw = DbUtilities.doSelect("tb_respaw", "tb_criatura", "a.id_criatura = b.id_criatura", "*", "a.id_area = " + idAreaAtual + " AND b.tx_nome like '%" + comando + "%' AND a.qt_atual > 0");
                            if (spaw.Read())
                            {
                                idMonstro = Convert.ToInt32(spaw["id_criatura"]);
                                idResp = Convert.ToInt32(spaw["id_respaw"]);
                                qtAtual = Convert.ToInt32(spaw["qt_atual"]) - 1;
                                nmMonstro = spaw["tx_nome"].ToString();
                                hpMonstro = Convert.ToInt32(spaw["nr_hp"]);
                                atkMonstro = Convert.ToInt32(spaw["nr_ataque"]);
                                defMonstro = Convert.ToInt32(spaw["nr_defesa"]);
                                agiMonstro = Convert.ToInt32(spaw["nr_agilidade"]);
                                desMonstro = Convert.ToInt32(spaw["nr_destreza"]);
                                exp = Convert.ToInt32(spaw["nr_exp"]);
                                gold = Convert.ToInt32(spaw["nr_gold"]);
                                txNome = spaw["tx_nome"].ToString();
                            }
                            else
                            {
                                Console.WriteLine("Não existe nenhum(a) " + comando + " nesta area.");
                            }

                            if (idResp > 0)
                            {
                                DbUtilities.doUpdate("tb_respaw", "qt_atual = " + qtAtual, "id_respaw = " + idResp);
                                DbUtilities.doUpdate("tb_personagem", "st_descansando = 'L'", "id_personagem = " + idPersonagem);

                                OdbcDataReader p = DbUtilities.doSelect("tb_personagem","","","*","id_personagem = " + idPersonagem);
                                if (p.Read())
                                {
                                    nivelAtual = Convert.ToInt32(p["nr_nivel"]);
                                    expAtual = Convert.ToInt32(p["nr_exp"]);
                                    ouroAtual = Convert.ToInt32(p["nr_ouro"]);
                                    expNecessario = Convert.ToInt32(p["nr_exp_next"]);
                                    nmPlay = p["tx_nome"].ToString();
                                    hpPlay = Convert.ToInt32(p["nr_hp"]);
                                    mpPlay = Convert.ToInt32(p["nr_mp"]);
                                    atkPlay = Convert.ToInt32(p["nr_ataque"]);
                                    defPlay = Convert.ToInt32(p["nr_defesa"]);
                                    agiPlay = Convert.ToInt32(p["nr_agilidade"]);
                                    desPlay = Convert.ToInt32(p["nr_destreza"]);
                                    intPlay = Convert.ToInt32(p["nr_inteligencia"]);
                                    conPlay = Convert.ToInt32(p["nr_concentracao"]);

                                    if (Convert.ToInt32(p["nr_contaefeito"]) > 0)
                                    {
                                        if (p["id_tipoefeito"].ToString().Equals("A"))
                                        {
                                            atkPlay += (Convert.ToInt32(atkPlay) * Convert.ToInt32(p["nr_variavel"])) / 100;
                                        }
                                        if (p["id_tipoefeito"].ToString().Equals("D"))
                                        {
                                            defPlay += (Convert.ToInt32(defPlay) * Convert.ToInt32(p["nr_variavel"])) / 100;
                                        }
                                        if (p["id_tipoefeito"].ToString().Equals("L"))
                                        {
                                            modLoot = Convert.ToInt32(p["nr_variavel"]);
                                        }
                                        if (p["id_tipoefeito"].ToString().Equals("E"))
                                        {
                                            modExp = Convert.ToInt32(p["nr_variavel"]);
                                        }
                                        if (p["id_tipoefeito"].ToString().Equals("G"))
                                        {
                                            modOuro = Convert.ToInt32(p["nr_variavel"]);
                                        }
                                        if (p["id_tipoefeito"].ToString().Equals("I"))
                                        {
                                            intPlay += (Convert.ToInt32(intPlay) * Convert.ToInt32(p["nr_variavel"])) /100;
                                        }
                                        if (p["id_tipoefeito"].ToString().Equals("C"))
                                        {
                                            conPlay += (conPlay * Convert.ToInt32(p["nr_variavel"])) / 100;
                                        }
                                    }
                                }
                                string classeItem = "";
                                int danoItem = 0;
                                OdbcDataReader itens = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "a.tx_equipado != '' AND a.id_personagem = " + idPersonagem);
                                while (itens.Read())
                                {
                                    atkPlay += Convert.ToInt32(itens["nr_ataque"]);
                                    defPlay += Convert.ToInt32(itens["nr_defesa"]);
                                    agiPlay += Convert.ToInt32(itens["nr_agilidade"]);
                                    desPlay += Convert.ToInt32(itens["nr_destreza"]);
                                    intPlay += Convert.ToInt32(itens["nr_inteligencia"]);
                                    conPlay += Convert.ToInt32(itens["nr_concentracao"]);
                                    if (!itens["id_classe"].ToString().Equals(""))
                                    {
                                        classeItem = itens["id_classe"].ToString();
                                    }
                                    danoItem += Convert.ToInt32(itens["nr_dano"]);
                                }

                                if (classeItem.Equals("M") && mpPlay <= 0)
                                {
                                    Console.WriteLine("Você não possui pontos de mana para poder enfrentar esta criatura com uma arma de classe mágica.");
                                }
                                else
                                {
                                    int nrAtualPer = 0;
                                    int idPericiaPer = 0;
                                    int nrNecessarioPer = 0;
                                    int idProximaPer = 0;
                                    string descPer = "";
                                    OdbcDataReader pericias = DbUtilities.doSelect("tb_pericia_personagem", "tb_pericia", "a.id_pericia = b.id_pericia", "*", "a.st_situacao = 'X' AND a.id_personagem = " + idPersonagem + " AND id_classe = '" + classeItem + "'");
                                    if (pericias.Read())
                                    {
                                        idPericiaPer = Convert.ToInt32(pericias["id_pericia_personagem"]);
                                        nrAtualPer = Convert.ToInt32(pericias["nr_atual"]);
                                        idProximaPer = Convert.ToInt32(pericias["id_proxima"]);
                                        nrNecessarioPer = Convert.ToInt32(pericias["nr_necessario"]);
                                        descPer = pericias["tx_nome"].ToString();
                                    }
                                    string tipoUpPer = "";
                                    int ataquePer = 0;
                                    int agilidadePer = 0;
                                    int defesaPer = 0;
                                    int destrezaPer = 0;
                                    int inteliPer = 0;
                                    int concentPer = 0;
                                    int hpPer = 0;
                                    int danoPer = 0;
                                    int idPerAtual = 0;
                                    OdbcDataReader perAtual = DbUtilities.doSelect("tb_pericia_personagem", "tb_pericia", "a.id_pericia = b.id_pericia", "*", "a.st_situacao = 'O' AND a.id_personagem = " + idPersonagem + " AND id_classe = '" + classeItem + "'");
                                    if (perAtual.Read())
                                    {
                                        idPerAtual = Convert.ToInt32(perAtual["id_pericia_personagem"]);
                                        tipoUpPer = perAtual["id_tipo"].ToString();
                                        ataquePer = Convert.ToInt32(perAtual["nr_ataque"]);
                                        defesaPer = Convert.ToInt32(perAtual["nr_defesa"]);
                                        agilidadePer = Convert.ToInt32(perAtual["nr_agilidade"]);
                                        destrezaPer = Convert.ToInt32(perAtual["nr_destreza"]);
                                        inteliPer = Convert.ToInt32(perAtual["nr_inteligencia"]);
                                        concentPer = Convert.ToInt32(perAtual["nr_concentracao"]);
                                        hpPer = Convert.ToInt32(perAtual["nr_hp"]);
                                        danoPer = Convert.ToInt32(perAtual["nr_dano"]);
                                    }

                                    if (tipoUpPer.Equals("V"))
                                    {
                                        atkPlay += ataquePer;
                                        defPlay += defesaPer;
                                        agiPlay += agilidadePer;
                                        desPlay += destrezaPer;
                                        intPlay += inteliPer;
                                        conPlay += concentPer;
                                    }
                                    if (tipoUpPer.Equals("P"))
                                    {
                                        ataquePer = (atkPlay * ataquePer) / 100;
                                        atkPlay += ataquePer;

                                        defesaPer = (defPlay * defesaPer) / 100;
                                        defPlay += defesaPer;

                                        agilidadePer = (agiPlay * agilidadePer) / 100;
                                        agiPlay += agilidadePer;

                                        destrezaPer = (desPlay * destrezaPer) / 100;
                                        desPlay += destrezaPer;

                                        inteliPer = (intPlay * inteliPer) / 100;
                                        intPlay += inteliPer;

                                        concentPer = (conPlay * concentPer) / 100;
                                        conPlay += concentPer;
                                    }

                                    int danoMaxMonstro = atkMonstro * 1000;
                                    int resMaxMonstro = (defMonstro * 500) + (atkMonstro * 200);
                                    int danoMaxPlayer = atkPlay * 1000;
                                    int resMaxPlayer = (nivelAtual * 500) + (defPlay * 800) + (atkPlay * 500);
                                    if (classeItem.Equals("M"))
                                    {
                                        resMaxPlayer = (nivelAtual * 800) + (defPlay * 500) + (atkPlay * 200);
                                    }

                                    int acertaMaxMonstro = desMonstro * 1000;
                                    int escapaMaxPlayer = Convert.ToInt32(((nivelAtual * 1.8) + (agiPlay * 1.8)) - 6) * 1000;
                                    int escapaMaxMonstro = agiMonstro * 1000;
                                    int danoMagicoMaxPlayer = intPlay * 750;

                                    Random rand = new Random();
                                    int danoMonstro = 0;
                                    int danoPlayer = 0;
                                    int resMonstro = 0;
                                    int resPlayer = 0;
                                    int acertaPlay = 0;
                                    int acertaMonstro = 0;
                                    int escapaPlay = 0;
                                    int escapaMonstro = 0;

                                    while (hpMonstro > 0 && hpPlay > 0)
                                    {
                                        if (classeItem.Equals("M"))
                                        {
                                            danoMaxPlayer = (nivelAtual * 500) + (intPlay * 500) + (conPlay * 300);
                                            acertaPlay = rand.Next(0, (nivelAtual * 500) + (conPlay * 600) + (desPlay * 600));
                                        }
                                        else
                                        {
                                            if (classeItem.Equals("D"))
                                            {
                                                danoMaxPlayer = (nivelAtual * 500) + (atkPlay * 500) + (desPlay * 700);
                                                acertaPlay = rand.Next(0, (nivelAtual * 500) + (desPlay * 1400));
                                            }
                                            else
                                            {
                                                danoMaxPlayer = (nivelAtual * 500) + (atkPlay * 800) + (desPlay * 400);
                                                acertaPlay = rand.Next(0, (nivelAtual * 500) + (desPlay * 600) + (atkPlay * 600));
                                            }
                                        }

                                        danoMaxPlayer += (danoItem * 1000);
                                        danoPlayer = rand.Next((danoMaxPlayer * 60) / 100, danoMaxPlayer);
                                            

                                        resMonstro = rand.Next(0, resMaxMonstro);
                                        escapaMonstro = rand.Next(0, escapaMaxMonstro);

                                        if (acertaPlay > escapaMonstro)
                                        {

                                            if (tipoUpPer.Equals("V"))
                                            {
                                                danoPlayer += danoPer;
                                            }
                                            if (tipoUpPer.Equals("P"))
                                            {
                                                danoPlayer += (danoPlayer * danoPer) / 100;
                                            }

                                            if (classeItem.Equals("M")) //caso seja um ataque magico
                                            {
                                                if (mpPlay > 0)
                                                {
                                                    mpPlay -= 2;
                                                }
                                                else
                                                {
                                                    danoPlayer = 0;
                                                }
                                            }
                                            else
                                                danoPlayer -= resMonstro;

                                            danoPlayer = danoPlayer / 1000;

                                            if (danoPlayer > 0)
                                            {
                                                string critico = "";

                                                if (!classeItem.Equals("M"))
                                                {
                                                    if (danoPlayer >= (danoMaxPlayer - (danoMaxPlayer * 20) / 100))
                                                    {
                                                        int critical = rand.Next(0, 100000);
                                                        if (critical < 30000)
                                                        {
                                                            danoPlayer += (danoPlayer * 40) / 100;
                                                            critico = "Critico!";
                                                        }
                                                    }
                                                }

                                                Console.WriteLine("-->> [" + hpPlay + "] " + nmPlay + " atacou " + nmMonstro + " causando " + danoPlayer + " pontos de dano." + "[" + hpMonstro + "] " + critico);
                                                hpMonstro -= danoPlayer;

                                                nrAtualPer++;

                                                System.Threading.Thread.Sleep(500);
                                            }
                                        }
                                        if (hpMonstro > 0)
                                        {
                                            danoMonstro = rand.Next((danoMaxMonstro * 60) / 100, danoMaxMonstro);
                                            resPlayer = rand.Next(0, resMaxPlayer);
                                            acertaMonstro = rand.Next(0, acertaMaxMonstro);
                                            escapaPlay = rand.Next(0, escapaMaxPlayer);

                                            if (acertaMonstro > escapaPlay)
                                            {
                                                danoMonstro -= resPlayer;
                                                danoMonstro = danoMonstro / 1000;

                                                if (danoMonstro > 0)
                                                {
                                                    string critico = "";

                                                    if (danoMonstro >= (danoMaxMonstro - (danoMaxMonstro * 30) / 100))
                                                    {
                                                        int critical = rand.Next(0, 100000);
                                                        if (critical < 10000)
                                                        {
                                                            danoMonstro += (danoMonstro * 40) / 100;
                                                            critico = "Critico!";
                                                        }
                                                    }


                                                    hpPlay -= danoMonstro;
                                                    Console.WriteLine("<<-- [" + hpPlay + "] " + nmMonstro + " atacou " + nmPlay + " causando " + danoMonstro + " pontos de dano." + "[" + hpMonstro + "] " + critico);
                                                    System.Threading.Thread.Sleep(500);
                                                }
                                            }
                                            if (mpPlay == 0 && classeItem.Equals("M"))
                                            {
                                                Console.WriteLine("... seu mana acabou, não poderá mais realizar ataques mágicos.");
                                                Console.Write("[.fu/.i]");
                                                comando = Console.ReadLine();
                                                if (comando.Equals(".fu"))
                                                {
                                                    acertaMonstro = rand.Next(0, acertaMaxMonstro + (danoMaxMonstro / 2));
                                                    escapaPlay = rand.Next(0, escapaMaxPlayer + (resMaxPlayer / 2));

                                                    if (escapaPlay > acertaMonstro)
                                                    {
                                                        exp = 0;
                                                        Console.WriteLine("Você fugiu da batalha.");
                                                        DbUtilities.doUpdate("tb_respaw", "qt_atual = " + qtAtual+1, "id_respaw = " + idResp);

                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Você não conseguiu fugir.");
                                                        comando = "";
                                                    }
                                                }
                                                if (comando.Equals(".i"))
                                                {
                                                    int mpMax = 0;
                                                    OdbcDataReader perso = DbUtilities.doSelect("tb_personagem", "", "", "*", "id_personagem = " + idPersonagem);
                                                    if (perso.Read())
                                                    {
                                                        mpMax = Convert.ToInt32(perso["nr_mp_max"]);
                                                    }

                                                    int idItemUsa = 0;
                                                    OdbcDataReader reader = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "a.id_personagem = " + idPersonagem + " AND b.id_tipo = 'I'");
                                                    if (reader.Read())
                                                    {
                                                        if (Convert.ToInt32(reader["nr_mp"]) > 0)
                                                        {
                                                            idItemUsa = Convert.ToInt32(reader["id_inventario"]);

                                                            mpMax = (mpMax * Convert.ToInt32(reader["nr_mp"])) / 100;
                                                            mpPlay += mpMax;

                                                            Console.WriteLine("Você recuperou " + mpMax + " pontos de mana.");
                                                        }
                                                    }
                                                    if (idItemUsa > 0)
                                                    {
                                                        DbUtilities.doQuery("DELETE FROM tb_inventario WHERE id_inventario = " + idItemUsa);
                                                        DbUtilities.doInsert("tb_inventario", "id_personagem,id_item,tx_equipado", idPersonagem + ",24,''");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Você não possui poções de mana para utilizar.");
                                                    }
                                                }
                                            }

                                            if (comando.Equals(".fu"))
                                                break;

                                            if (hpPlay < danoMaxMonstro / 1000 && hpPlay > 0)
                                            {
                                                Console.WriteLine("... você está com pouca energia.");
                                                bool segue = true;
                                                while (segue)
                                                {
                                                    Console.Write("[.fu/.i]: ");
                                                    comando = Console.ReadLine();

                                                    if (comando.Equals(".fu"))
                                                    {
                                                        acertaMonstro = rand.Next(0, acertaMaxMonstro + (danoMaxMonstro / 2));
                                                        escapaPlay = rand.Next(0, escapaMaxPlayer + (resMaxPlayer / 2));

                                                        if (escapaPlay > acertaMonstro)
                                                        {
                                                            exp = 0;
                                                            Console.WriteLine("Você fugiu da batalha.");
                                                            DbUtilities.doUpdate("tb_respaw", "qt_atual = " + qtAtual+1, "id_respaw = " + idResp);

                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Você não conseguiu fugir.");
                                                            comando = "";
                                                        }

                                                        segue = false;
                                                    }
                                                    if (comando.Equals(".i"))
                                                    {
                                                        int hpmax = 0;
                                                        OdbcDataReader perso = DbUtilities.doSelect("tb_personagem", "", "", "*", "id_personagem = " + idPersonagem);
                                                        if (perso.Read())
                                                        {
                                                            hpmax = Convert.ToInt32(perso["nr_hp_max"]);
                                                        }

                                                        int idItemUsa = 0;
                                                        OdbcDataReader reader = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "a.id_personagem = " + idPersonagem + " AND b.id_tipo = 'I'");
                                                        while (reader.Read())
                                                        {
                                                            if (Convert.ToInt32(reader["nr_hp"]) > 0)
                                                            {
                                                                idItemUsa = Convert.ToInt32(reader["id_inventario"]);
                                                                segue = false;

                                                                hpmax = (hpmax * Convert.ToInt32(reader["nr_hp"])) / 100;
                                                                hpPlay += hpmax;

                                                                Console.WriteLine("Você recuperou " + hpmax + " pontos de energia.");
                                                                break;
                                                            }
                                                        }
                                                        if (idItemUsa > 0)
                                                        {
                                                            DbUtilities.doQuery("DELETE FROM tb_inventario WHERE id_inventario = " + idItemUsa);
                                                            DbUtilities.doInsert("tb_inventario", "id_personagem,id_item,tx_equipado", idPersonagem + ",24,''");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Você não possui poções de cura para utilizar.");
                                                        }
                                                    }
                                                    if (comando.Equals(""))
                                                    {
                                                        segue = false;
                                                    }
                                                }
                                                if (comando.Equals(".fu"))
                                                    break;
                                            }
                                        }
                                    }

                                    if (nrAtualPer >= nrNecessarioPer)
                                    {
                                        nrAtualPer = nrAtualPer - nrNecessarioPer;
                                        if (idPericiaPer > 0)
                                        {
                                            Console.WriteLine(">>> Você se tornou um " + descPer + "! <<<");
                                            DbUtilities.doUpdate("tb_pericia_personagem", "st_situacao = 'O'", "id_pericia_personagem = " + idPericiaPer);
                                            DbUtilities.doQuery("DELETE FROM tb_pericia_personagem WHERE id_pericia_personagem = " + idPerAtual);
                                        }
                                        else
                                        {
                                            OdbcDataReader prim = DbUtilities.doSelect("tb_pericia", "", "", "*", "st_primeira = 'X' AND id_classe = '" + classeItem + "'");
                                            if (prim.Read())
                                            {
                                                idProximaPer = Convert.ToInt32(prim["id_pericia"]);
                                            }
                                        }
                                        if (idProximaPer > 0)
                                        {
                                            DbUtilities.doInsert("tb_pericia_personagem", "id_personagem,id_pericia,nr_atual,st_situacao", idPersonagem + "," + idProximaPer + "," + nrAtualPer + ",'X'");
                                        }
                                    }
                                    else
                                    {
                                        DbUtilities.doUpdate("tb_pericia_personagem", "nr_atual = " + nrAtualPer, "id_pericia_personagem = " + idPericiaPer);
                                    }

                                    if (!comando.Equals(".fu"))
                                    {
                                        if (hpPlay > hpMonstro)
                                        {
                                            int idQuestPer = 0;
                                            bool fez = false;
                                            OdbcDataReader quest = DbUtilities.doSelect("tb_quest_personagem", "tb_etapa_quest", "a.id_etapa_quest = b.id_etapa_quest", "a.id_quest_personagem,a.nr_contador as conta, b.nr_contador as total", "a.id_personagem = " + idPersonagem + " AND b.id_tipo = 'H' AND b.id_criatura = " + idMonstro);
                                            if (quest.Read())
                                            {
                                                idQuestPer = Convert.ToInt32(quest["id_quest_personagem"]);

                                                if (Convert.ToInt32(quest["conta"]) + 1 == Convert.ToInt32(quest["total"]))
                                                {
                                                    fez = true;
                                                }
                                            }
                                            if (idQuestPer > 0)
                                            {
                                                if (fez)
                                                {
                                                    DbUtilities.doUpdate("tb_quest_personagem", "nr_contador = nr_contador + 1, st_situacao = 'X'", "id_quest_personagem = " + idQuestPer);
                                                    Console.WriteLine("Seu quadro de missões foi atualizado.");
                                                }
                                                else
                                                {
                                                    DbUtilities.doUpdate("tb_quest_personagem", "nr_contador = nr_contador + 1", "id_quest_personagem = " + idQuestPer);
                                                }
                                            }

                                            gold = rand.Next(0, gold);
                                            gold = (gold * (100 + modOuro)) / 100;

                                            exp = (exp * (100 + modExp)) / 100;

                                            Console.WriteLine(nmPlay + " venceu!");
                                            Console.WriteLine("Você ganhou " + exp + " pontos de experiência.");
                                            if (gold > 0)
                                            {
                                                Console.WriteLine("Você ganhou " + gold + " moedas de ouro.");
                                            }

                                            if (expAtual + exp >= expNecessario)
                                            {
                                                nivelAtual++;
                                                int ExpNext = Convert.ToInt32(Math.Round((80.000000000 / 3) * Math.Pow(nivelAtual, 3) - (80 * Math.Pow(nivelAtual, 2)) + ((850.000000000 / 3) * nivelAtual - 210)));
                                                Console.WriteLine("########## Você avançou do nível " + (nivelAtual - 1).ToString() + " para o nível " + nivelAtual + "! ##########");
                                                DbUtilities.doUpdate("tb_personagem", "st_descansando = 'N', nr_exp = nr_exp + " + exp + ",nr_pontos_atributo = nr_pontos_atributo + 6, nr_exp_next = " + ExpNext + ", nr_nivel = " + nivelAtual + ", nr_hp_max = (55 + ( " + nivelAtual + " * (nr_vitalidade*2))), nr_hp = nr_hp_max, nr_mp_max = (20 + (" + nivelAtual + " * (nr_composicao * 2))),nr_mp = nr_mp_max", "id_personagem = " + idPersonagem);
                                            }
                                            else
                                            {
                                                DbUtilities.doUpdate("tb_personagem", "st_descansando = 'N', nr_hp = " + hpPlay + ", nr_mp = " + mpPlay + ", nr_exp = nr_exp + " + exp + ", nr_ouro = nr_ouro + " + gold, "id_personagem = " + idPersonagem);
                                            }

                                            OdbcDataReader loot = DbUtilities.doSelect("tb_loot", "tb_item", "a.id_item = b.id_item", "*", "id_criatura = " + idMonstro);

                                            List<string> itLoot = new List<string>();

                                            while (loot.Read())
                                            {
                                                int cai = rand.Next(0, 100000);
                                                int probab = (Convert.ToInt32(loot["vl_probabilidade"]) * (100 + modLoot)) / 100;
                                                if (probab >= cai)
                                                {
                                                    Console.WriteLine(nmMonstro + " deixou cair " + loot["tx_nome"]);
                                                    itLoot.Add(loot["id_item"].ToString());
                                                }
                                            }

                                            foreach (string itl in itLoot)
                                            {
                                                DbUtilities.doInsert("tb_item_area", "id_area,id_item", idAreaAtual + "," + itl);
                                            }
                                        }
                                        else
                                        {
                                            gold = Convert.ToInt32((ouroAtual * 0.1));
                                            Console.WriteLine(nmMonstro + " venceu!");
                                            Console.WriteLine("##################################################");
                                            Console.WriteLine("##########       G A M E  O V E R       ##########");
                                            Console.WriteLine("##################################################");
                                            int ExpPerdida = Convert.ToInt32(expAtual * 0.1);
                                            Console.WriteLine("Você perdeu " + ExpPerdida + " pontos de experiência.");
                                            Console.WriteLine("Você perdeu " + gold + " moedas de ouro.");
                                            DbUtilities.doUpdate("tb_personagem", "st_descansando = 'N', id_area = 1, nr_hp = nr_hp_max, nr_mp = nr_mp_max, nr_exp = nr_exp - " + ExpPerdida + ", nr_ouro = nr_ouro - " + gold, "id_personagem = " + idPersonagem);
                                            OdbcDataReader invMorreu = DbUtilities.doSelect("tb_inventario", "tb_item", "a.id_item = b.id_item", "*", "a.id_personagem = " + idPersonagem);
                                            List<string[]> lPerdeu = new List<string[]>();
                                            while (invMorreu.Read())
                                            {
                                                int perdeu = rand.Next(0, 100000);
                                                if (perdeu < 10000)
                                                {
                                                    Console.WriteLine("Você perdeu " + invMorreu["tx_nome"].ToString());
                                                    string[] prd = new string[2] { invMorreu["id_inventario"].ToString(), invMorreu["id_item"].ToString() };
                                                    lPerdeu.Add(prd);
                                                }
                                            }
                                            foreach (string[] it in lPerdeu)
                                            {
                                                DbUtilities.doQuery("DELETE FROM tb_inventario WHERE id_inventario = " + it[0]);
                                                DbUtilities.doInsert("tb_item_area", "id_area,id_item", idAreaAtual + "," + it[1]);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        DbUtilities.doUpdate("tb_personagem", "st_descansando = 'N', nr_hp = " + hpPlay + ", nr_mp = " + mpPlay, "id_personagem = " + idPersonagem);
                                    }
                                }
                            }
                        }

                        if (comando.Equals(".desc"))
                        {
                            int ouro = 0;
                            OdbcDataReader reader = DbUtilities.doSelect("tb_personagem", "", "", "*", "id_personagem = " + idPersonagem);
                            if (reader.Read())
                            {
                                ouro = Convert.ToInt32(reader["nr_ouro"]);
                            }

                            if (ouro >= 50)
                            {
                                DbUtilities.doUpdate("tb_personagem", "st_descansando = 'S', nr_ouro = nr_ouro - 50", "id_personagem = " + idPersonagem);
                        
                                Console.WriteLine("Você está descansando... Prescione ENTER quando quiser terminar o descanso.");
                                Console.ReadLine();

                                DbUtilities.doUpdate("tb_personagem", "st_descansando = 'N'", "id_personagem = " + idPersonagem);

                                Console.WriteLine("Você recuperou suas energias.");
                            }
                            else
                            {
                                Console.WriteLine("Você precisa de ao menos 50 moedas de ouro para descansar aqui.");
                            }
                        }

                        if (comando.Equals(".li"))
                        {
                            Console.WriteLine("+--------------------------+----------------+-----------------+");
                            Console.WriteLine("| Item                     | Preço de venda | Preço de compra |");
                            Console.WriteLine("+--------------------------+----------------+-----------------+");
                            OdbcDataReader itens = DbUtilities.doSelect("tb_loja", "tb_item", "a.id_item = b.id_item", "*", "a.id_area = " + idAreaAtual + " ORDER BY id_ordem");
                            while (itens.Read())
                            {
                                /*string atdef = "";
                                if (!itens["id_tipo"].ToString().Equals("M") && !itens["id_tipo"].ToString().Equals("I"))
                                {
                                    if (Convert.ToInt32(itens["nr_ataque"]) > 0)
                                    {
                                        atdef = "(+" + itens["nr_ataque"].ToString() + ",";
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(itens["nr_ataque"]) < 0)
                                            atdef = "(" + itens["nr_ataque"].ToString() + ",";
                                        else
                                            atdef = "(+0,";
                                    }

                                    if (Convert.ToInt32(itens["nr_defesa"]) > 0)
                                    {
                                        atdef += "+" + itens["nr_defesa"].ToString() + ")";
                                    }
                                    else
                                    {
                                        if (Convert.ToInt32(itens["nr_defesa"]) < 0)
                                            atdef += itens["nr_defesa"].ToString() + ")";
                                        else
                                            atdef += "+0)";
                                    }
                                }*/
                                string preco = "-";
                                if (!itens["vl_venda"].ToString().Equals("0"))
                                {
                                    preco = itens["vl_venda"].ToString() + "g";
                                }
                                Console.WriteLine("| " + (itens["tx_nome"].ToString()).PadRight(30,' ') + "  " + (preco).PadRight(15, ' ') + "  " + (itens["vl_compra"].ToString() + "g").PadRight(10,' ') + " |");
                            }
                            Console.WriteLine("+-------------------------------------------------------------+");
                        }

                        if (comando.Equals(".c"))
                        {
                            OdbcDataReader inventario = DbUtilities.doSelect("tb_inventario", "", "", "*", "id_personagem = " + idPersonagem);
                            int contar = 0;
                            while (inventario.Read())
                            {
                                contar++;
                            }
                            if (contar == maximaCarga)
                            {
                                Console.WriteLine("Você não possui espaço para carregar mais itens.");
                            }
                            else
                            {

                                Console.Write("Qual item deseja comprar?: ");
                                comando = Console.ReadLine();
                                OdbcDataReader itens = DbUtilities.doSelect("tb_loja", "tb_item", "a.id_item = b.id_item", "*", "a.id_area = " + idAreaAtual + " AND a.vl_venda > 0 AND b.tx_nome = '" + comando + "'");
                                int idItem = 0;
                                int vlItem = 0;
                                if (itens.Read())
                                {
                                    idItem = Convert.ToInt32(itens["id_item"]);
                                    vlItem = Convert.ToInt32(itens["vl_venda"]);
                                }
                                else
                                {
                                    Console.WriteLine(comando + " não está disponível para compra.");
                                }

                                int ouroP = 0;
                                OdbcDataReader p = DbUtilities.doSelect("tb_personagem", "", "", "*", "id_personagem = " + idPersonagem);
                                if (p.Read())
                                {
                                    ouroP = Convert.ToInt32(p["nr_ouro"]);
                                }

                                if (ouroP >= vlItem)
                                {
                                    if (idItem > 0)
                                    {
                                        DbUtilities.doInsert("tb_inventario", "id_personagem,id_item,tx_equipado", idPersonagem + "," + idItem + ",''");
                                        DbUtilities.doUpdate("tb_personagem", "nr_ouro = nr_ouro - " + vlItem, "id_personagem = " + idPersonagem);
                                        Console.WriteLine("Você comprou " + comando);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Você não tem ouro suficiente para comprar " + comando);
                                }
                            }
                        }

                        if (comando.Equals(".ve"))
                        {
                            Console.Write("Qual item deseja vender?: ");
                            comando = Console.ReadLine();
                            OdbcDataReader itens = DbUtilities.doSelect("tb_loja", "tb_item", "a.id_item = b.id_item", "*", "a.id_area = " + idAreaAtual + " AND b.tx_nome = '" + comando + "'");
                            int idItem = 0;
                            int vlItem = 0;
                            if (itens.Read())
                            {
                                idItem = Convert.ToInt32(itens["id_item"]);
                                vlItem = Convert.ToInt32(itens["vl_compra"]);
                            }
                            else
                            {
                                Console.WriteLine(comando + " não está disponível para venda.");
                            }

                            int idInvent = 0;
                            OdbcDataReader p = DbUtilities.doSelect("tb_inventario", "", "", "*", "id_personagem = " + idPersonagem + " AND id_item = " + idItem + " ORDER BY tx_equipado");
                            if (p.Read())
                            {
                                idInvent = Convert.ToInt32(p["id_inventario"]);
                            }

                            if (idInvent > 0)
                            {
                                DbUtilities.doQuery("DELETE FROM tb_inventario WHERE id_inventario = " + idInvent);
                                DbUtilities.doUpdate("tb_personagem", "nr_ouro = nr_ouro + " + vlItem, "id_personagem = " + idPersonagem);
                                Console.WriteLine("Você vendeu " + comando + " por " + vlItem + "g");
                            }
                        }

                        if (comando.Equals(".n"))
                        {
                            if (idNorte > 0)
                            {
                                string desc = "";
                                OdbcDataReader reader = DbUtilities.doSelect("tb_area", "", "", "*", "id_area = " + idNorte);
                                if (reader.Read())
                                {
                                    desc = reader["tx_nome"].ToString();
                                }
                                DbUtilities.doUpdate("tb_personagem", "id_area = " + idNorte, "id_personagem = " + idPersonagem);
                                Console.WriteLine("Você seguiu ao norte para " + desc);
                            }
                        }

                        if (comando.Equals(".s"))
                        {
                            if (idSul > 0)
                            {
                                string desc = "";
                                OdbcDataReader reader = DbUtilities.doSelect("tb_area", "", "", "*", "id_area = " + idSul);
                                if (reader.Read())
                                {
                                    desc = reader["tx_nome"].ToString();
                                }
                                DbUtilities.doUpdate("tb_personagem", "id_area = " + idSul, "id_personagem = " + idPersonagem);
                                Console.WriteLine("Você seguiu ao sul para " + desc);
                            }
                        }

                        if (comando.Equals(".l"))
                        {
                            if (idLeste > 0)
                            {
                                string desc = "";
                                OdbcDataReader reader = DbUtilities.doSelect("tb_area", "", "", "*", "id_area = " + idLeste);
                                if (reader.Read())
                                {
                                    desc = reader["tx_nome"].ToString();
                                }
                                DbUtilities.doUpdate("tb_personagem", "id_area = " + idLeste, "id_personagem = " + idPersonagem);
                                Console.WriteLine("Você seguiu ao leste para " + desc);
                            }
                        }

                        if (comando.Equals(".o"))
                        {
                            if (idOeste > 0)
                            {
                                string desc = "";
                                OdbcDataReader reader = DbUtilities.doSelect("tb_area", "", "", "*", "id_area = " + idOeste);
                                if (reader.Read())
                                {
                                    desc = reader["tx_nome"].ToString();
                                }
                                DbUtilities.doUpdate("tb_personagem", "id_area = " + idOeste, "id_personagem = " + idPersonagem);
                                Console.WriteLine("Você seguiu ao oeste para " + desc);
                            }
                        }

                        if (comando.Equals(".dp"))
                        {
                            if (idDepot > 0)
                            {
                                DbUtilities.doUpdate("tb_personagem", "id_area = " + idDepot, "id_personagem = " + idPersonagem);
                                Console.WriteLine("Você entrou no Depósito.");
                            }
                        }

                        if (comando.Equals(".lj"))
                        {
                            if (idLoja > 0)
                            {
                                DbUtilities.doUpdate("tb_personagem", "id_area = " + idLoja, "id_personagem = " + idPersonagem);
                                Console.WriteLine("Você entrou na Loja.");
                            }
                        }

                        if (comando.Equals(".e"))
                        {
                            if (idEstalagem > 0)
                            {
                                DbUtilities.doUpdate("tb_personagem", "id_area = " + idEstalagem, "id_personagem = " + idPersonagem);
                                Console.WriteLine("Você entrou na Estalagem.");
                            }
                        }

                        if (comando.Equals(".fe"))
                        {
                            if (idFerreiro > 0)
                            {
                                DbUtilities.doUpdate("tb_personagem", "id_area = " + idFerreiro, "id_personagem = " + idPersonagem);
                                Console.WriteLine("Você entrou na Barraca do Ferreiro.");
                            }
                        }

                        if (comando.Equals(".t"))
                        {
                            if (idTenda > 0)
                            {
                                DbUtilities.doUpdate("tb_personagem", "id_area = " + idTenda, "id_personagem = " + idPersonagem);
                                Console.WriteLine("Você entrou na Tenda de Alquimia.");
                            }
                        }
                    }
                }

                Console.WriteLine("Até logo...");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro crítico: " + ex.Message);
            }
        }

        private static void doMine(int modMinerar, int idAreaAtual, int idPersonagem, int segundos)
        {
            while (true)
            {
                Console.WriteLine("Cha!! Ching!!");

                OdbcDataReader loot = DbUtilities.doSelect("tb_mina", "tb_item", "a.id_item = b.id_item", "*", "id_area = " + idAreaAtual);

                List<string> itLoot = new List<string>();
                Random rand = new Random();
                while (loot.Read())
                {
                    int cai = rand.Next(0, 100000);
                    int probab = (Convert.ToInt32(loot["vl_probabilidade"]) * (100 + modMinerar)) / 100;
                    if (probab >= cai)
                    {
                        Console.WriteLine("Você encontrou " + loot["tx_nome"]);
                        itLoot.Add(loot["id_item"].ToString());
                    }
                }

                foreach (string itl in itLoot)
                {
                    DbUtilities.doInsert("tb_inventario", "id_personagem,id_item", idPersonagem + "," + itl);
                }
                Thread.Sleep(segundos*1000);
            }
        }
    }
}
