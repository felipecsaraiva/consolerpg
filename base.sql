-- MySQL dump 10.13  Distrib 5.6.24, for Win64 (x86_64)
--
-- Host: localhost    Database: dbconsole
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Dumping data for table `tb_acao_npc`
--

LOCK TABLES `tb_acao_npc` WRITE;
/*!40000 ALTER TABLE `tb_acao_npc` DISABLE KEYS */;
INSERT INTO `tb_acao_npc` VALUES (1,1,'!jornada',1,'Olá aventureiro. Vejo que você está começando a sua jornada agora. Vou te ensinar alguns comandos básicos. Primeiro, pegue o pergaminho em cima do altar. Para isso basta usar o comando .get'),(2,1,'!Anita',0,'Oi, eu sou Anita, a druida do templo. Se você está começando agora, pergunte-me sobre a !jornada.'),(3,3,'!Carlos',0,'Olá! Aqui você pode guardar suas coisas com segurança. Deixei alguns iteis para você no seu baú.\nPara ver o que há nele, use o comando .buscar\nEm seguida você pode .pegar ou .guardar o que desejar.'),(4,2,'!Bruno',2,'Ei! Você não deveria andar sem proteção por aí... Olha, vá até o Carlos no depósito, ele pode arranjar algumas coisas úteis, depois volte aqui. Também tenho algo... eu sei tudo sobre !batalha.'),(5,2,'!batalha',3,'Para batalhar, você deve usar o comando .f em seguida indicar a criatura que deseja enfrentar. Mas cuidado, estude bem o seu inimigo antes de arrumar confusão.'),(6,4,'!Diana',0,'Ah.. olá. Seja bem vindo. Tome um lugar ou escolha um quarto.. \nDesculpe. Estou ocupada com essas receitas de !inseticida contra !ratos. Eles estão infestando o lugar e assustando os clientes.'),(7,4,'!ratos',4,'É uma praga! Você pode me ajudar com eles? Ótimo!\nEles estão por toda a rede de esgotos da cidade. E às vezes invadem a minha Estalagem. Precisamos exterminá-los!\nConto com você!'),(8,4,'!inseticida',5,'Sim, é uma receita que estou estudando.\nOuvi dizer que você pode criá-lo usando técnicas de Alquimia.\nHá uma tenda no vilarejo a Oeste da cidade onde eles fazem essas coisas.');
/*!40000 ALTER TABLE `tb_acao_npc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_area`
--

LOCK TABLES `tb_area` WRITE;
/*!40000 ALTER TABLE `tb_area` DISABLE KEYS */;
INSERT INTO `tb_area` VALUES (1,'Templo','Você está no Templo, um salão oval rodeado por quatro enormes pilares  e  vitrais  que remontam  as histórias dos antigos deuses. \nHá um altar no centro da sala, recoberto por vários pergaminhos.\nUma mulher vestida com uma túnica branca aguarda próximo dali. Para falar com ela use o comando !Anita.\nAo SUL você vê uma enorme  porta dupla de madeira que leva até a Rua Principal.\nAo NORTE você vê uma portinhola que leva para os fundos do Templo.',10,2,0,0,0,0,0,0,0,'.n/.s/.desc/'),(2,'Rua Principal','Você está na Rua Principal, o chão é de pedras uniformes mas parece ser bem rudimentar. Ao norte você vê uma enorme construção bem iluminada com janelas coloridas. Ao sul você percebe o movimento da Praça Central. A rua se extende a leste e oeste.',1,3,5,4,0,0,0,0,0,'.n/.s/.l/.o/'),(3,'Praça Central','Você está na Praça Central, várias pessoas costumam andar por aqui. Existem vários comerciantes de rua comprando e vendendo iguarías. Uma enorme fonte de água cristalina se ergue no centro da praça, acima dela, uma estátua imponente de um herói antigo parece observar a movimentação ao redor. Ao norte passa uma rua. Ao sul, você vê a placa de uma Estalagem. A leste, uma loja de armas e a oeste uma pequena viela leva ao Portão da Cidade.',2,7,8,6,0,0,0,0,0,'.n/.s/.l/.o/.li/.c/.ve/'),(4,'Extenção da Rua Principal','Você está em uma extenção da Rua Principal. Ao sul você vê se erguerem enormes portões de ferro. Ao norte você vê a placa do Depósito. A rua segue a oeste.',9,6,2,0,0,0,0,0,0,'.n/.s/.l/'),(5,'Extenção da Rua Principal','Você está em uma extenção da Rua Principal. Parece um beco sem saída. O único caminho é voltar de onde você veio.',0,0,0,2,0,0,0,0,0,'.o/'),(6,'Portão da Cidade','Você está no Portão da Cidade, dois guardas observam atentamente os que passam por aqui. A leste você vê a Praça Central. Uma rua parece começar ao norte.',4,12,3,16,0,0,0,0,0,'.n/.s/.l/.o/'),(7,'Estalagem','Você está em uma aconchegante Estalagem. A atendente no balcão parece estar distraída com algum tipo de livro nas mãos. A garçonete está por aqui anotando os pedidos. Você pode ver um mezanino que leva para os quartos. Ao norte, pelas janelas é possível ter a visão da Praça Central.',3,14,0,0,0,0,0,0,0,'.n/.s/.desc/'),(8,'Loja','Você está em uma pequena loja. Você vê diversas armas e equipamentos nas paredes e pelo chão. A porta de saída fica a oeste. Atrás de uma cortina de couro você vê uma pequena sala ao Sul',0,11,0,3,0,0,0,0,0,'.s/.o/.li/.c/.ve/'),(9,'Depósito','Você está em um grande salão com diversos baús bem organizados ao redor. A saída fica ao sul.',0,4,0,0,0,0,0,0,0,'.s/.buscar/.pegar/.guardar/'),(10,'Area de Treinamento','Você está em uma grande área aberta nos fundos do Templo. Uma aura parece encobrir o lugar.\nVários itens foram deixados aqui.\nAo sul, você vê uma pequena porta que leva até o interior do Templo.',0,1,0,0,0,0,0,0,0,'.s/'),(11,'Ferreiro','Você está em uma pequena sala. Atrás de um balcão improvisado, existe um grande martelo escorado sobre uma bigorna de ferro. Ao norte você vê uma pequena loja. Ao sul, uma porta leva até a Rua',8,15,0,0,0,0,0,0,0,'.n/.s/.forja/.fj/'),(12,'Rua Secundária','Você está no início da Rua Secundária, ela segue ao sul. Ao norte você vê o portão da cidade.',6,13,0,0,0,0,0,0,0,'.n/.s/'),(13,'Rua Secundária','Você está em uma extensão da Rua Secundária, que se extende ao Leste e Norte.',12,43,14,0,0,0,0,0,0,'.n/.s/.l/'),(14,'Rua Secundária','Você está na Rua Secundária, ao norte você vê a Estalagem, a rua segue para leste e oeste.',7,0,15,13,0,0,0,0,0,'.n/.l/.o/'),(15,'Rua Secundária','Você está no final da Rua Secundária, ela segue para o oeste. Ao norte você vê o Ferreiro.',11,0,0,14,0,0,0,0,0,'.n/.o/'),(16,'Arredores da Cidade','Você está nos arredores da cidade. Há uma pequena esstrada a Oeste. A Leste ficam os portões da cidade.',0,0,6,17,0,0,0,0,0,'.l/.o/'),(17,'Estrada','Você está em uma estrada de terra batida que segue a oeste. A Leste você vê os arredores da cidade.',0,0,16,18,0,0,0,0,0,'.l/.o/'),(18,'Estrada do Vilarejo','Você está na estrada do Vilarejo, que fica ao Norte. A estrada segue a leste e oeste.',19,32,17,21,0,0,0,0,0,'.n/.s/.l/.o/'),(19,'Vilarejo','Você está no Vilarejo. Ha uma estrada ao Sul. Há uma tenda a Oeste.',96,18,0,20,0,0,0,0,0,'.n/.s/.o/'),(20,'Tenda do Alquimista','Você está em uma pequena tenda armada no vilarejo. A saída fica a leste.',0,0,19,0,0,0,0,0,0,'.l/.alquimia/.al/'),(21,'Entrada da Floresta','Você está na entrada da floresta, que segue a Oeste. A Leste está a estrada que leva até a cidade.',0,0,18,22,0,0,0,0,0,'.l/.o/'),(22,'Floresta','Você está rodeado de árvores por todos os lados. Há luz vindo do Leste.',23,25,21,24,0,0,0,0,0,'.n/.s/.l/.o/'),(23,'Floresta','Você está rodeado de árvores por todos os lados.',81,22,0,27,0,0,0,0,0,'.n/.s/.o/'),(24,'Floresta','Você está rodeado de árvores por todos os lados.',0,26,22,29,0,0,0,0,0,'.s/.l/.o/'),(25,'Floresta','Você está rodeado de árvores por todos os lados.',22,0,0,26,0,0,0,0,0,'.n/.o/'),(26,'Floresta','Você está rodeado de árvores por todos os lados.',24,0,25,30,0,0,0,0,0,'.n/.l/.o/'),(27,'Floresta','Você está rodeado de árvores por todos os lados.',79,24,23,28,0,0,0,0,0,'.n/.s/.l/.o/'),(28,'Floresta','Você está rodeado de árvores por todos os lados.',80,29,27,0,0,0,0,0,0,'.n/.s/.l/'),(29,'Floresta','Você está rodeado de árvores por todos os lados.',28,30,24,0,0,0,0,0,0,'.n/.s/.l/'),(30,'Floresta','Você está rodeado de árvores por todos os lados.',29,31,26,0,0,0,0,0,0,'.n/.s/.l/'),(31,'Pantano','Você está com lama até as canelas. A Floresta fica ao Norte.',30,0,0,0,0,0,0,0,0,'.n/'),(32,'Estrada do Vilarejo','Você está na estrada do Vilarejo, ela segue ao norte e ao Sul',18,33,0,0,0,0,0,0,0,'.n/.s/'),(33,'Estrada do Vilarejo','Você está na estrada do Vilarejo, ela segue ao norte e ao Sul',32,34,0,0,0,0,0,0,0,'.n/.s/'),(34,'Campos','Você está nos campos próximos da Cidade. Ao Norte há uma estrada, os campos se extendem ao Sul e Leste',33,37,35,0,0,0,0,0,0,'.n/.s/.l/'),(35,'Campos','Você está nos campos próximos da Cidade. Eles se extendem a Sul e Oeste.',0,36,98,34,0,0,0,0,0,'.s/.l/.o/'),(36,'Campos','Você está nos campos próximos da Cidade. Eles se extendem a Norte e Oeste.',35,0,99,37,0,0,0,0,0,'.n/.l/.o/'),(37,'Campos','Você está nos campos próximos da Cidade. Eles se extendem a Sul e Leste. Ao Sul você vê as Montanhas',34,38,36,0,0,0,0,0,0,'.n/.s/.l/'),(38,'Montanhas','Você está nas Montanhas, ela se extende a Oeste. Ao Norte você vê os Campos e ao Sul a entrada das Cavernas.',37,39,0,40,0,0,0,0,0,'.n/.s/.o/'),(39,'Cavernas','Você está na entrada das Cavernas. Ao norte você segue para as Montanhas. A Caverna segue ao sul.',38,55,0,0,0,0,0,0,0,'.n/.s/'),(40,'Montanhas','Você está nas Montanhas, elas se extendem a Leste e Oeste',0,0,38,41,0,0,0,0,0,'.l/.o/'),(41,'Montanhas','Você está nas Montanhas, elas se extendem a Norte e Leste',42,0,40,0,0,0,0,0,0,'.n/.l/'),(42,'Montanhas','Você está na parte mais alta das Montanhas, ela seguem ao Sul.',0,41,0,0,0,0,0,0,0,'.s/'),(43,'Esgotos','Você está na rede de esgotos da cidade. Há uma escada que leva para a rua ao Norte. O esgoto segue para o leste.',13,0,44,0,0,0,0,0,0,'.n/.l/'),(44,'Esgotos','Você está na rede de esgotos da cidade. Ela se estende ao Norte, Leste e Oeste',53,0,45,43,0,0,0,0,0,'.n/.l/.o/'),(45,'Esgotos','Você está na rede de esgotos da cidade. Ela se estende a Norte e Oeste.',46,0,0,44,0,0,0,0,0,'.n/.o/'),(46,'Esgotos','Você está na rede de esgotos da cidade. Ela se extende a Norte, Sul e o Este',47,45,0,53,0,0,0,0,0,'.n/.s/.o/'),(47,'Esgotos','Você está na rede de esgotos da cidade. Ela se extende a Norte, Sul e Oeste',48,46,0,54,0,0,0,0,0,'.n/.s/.o/'),(48,'Esgotos','Você está na rede de esgotos da cidade. Ela se extende a Sul e Oeste. Há uma escada a Norte.',5,47,0,49,0,0,0,0,0,'.n/.s/.o/'),(49,'Esgotos','Você está na rede de esgotos da cidade. Ela se extende ao Sul, Leste e Oeste.',0,54,48,50,0,0,0,0,0,'.s/.l/.o/'),(50,'Esgotos','Você está na rede de esgotos da cidade. Ela se extende ao sul e a Leste',0,51,49,0,0,0,0,0,0,'.s/.l/'),(51,'Esgotos','Você está na rede de esgotos da cidade. Ela se extende a Norte, sul e Leste',50,52,54,0,0,0,0,0,0,'.n/.s/.l/'),(52,'Esgotos','Você está na rede de esgotos da cidade. Ela se Extende a Norte e Leste',51,0,53,0,0,0,0,0,0,'.n/.l/'),(53,'Esgotos','Você está na rede de esgotos da cidade. Ela se extende para todas as direções.',54,44,46,52,0,0,0,0,0,'.n/.s/.l/.o/'),(54,'Esgotos','Você está na rede de esgotos da cidade. Ela se extende para todas as direções',49,53,47,51,0,0,0,0,0,'.n/.s/.l/.o/'),(55,'Cavernas','Você está nas cavernas. A Entrada fica ao Norte, a caverna segue por túneis que parecem ter sido exculpidos por mineradores ao Sul',39,56,0,0,0,0,0,0,0,'.n/.s/'),(56,'Tuneis','Você está em uma espécie de Tunel exculpido nas paredes da caverna. O tunel segue para o sul. A caverna parece se divir a Norte, Leste e Oeste.',55,57,59,58,0,0,0,0,0,'.n/.s/.l/.o/'),(57,'Tuneis','Você está em uma espécie de Tunel exculpido nas paredes da caverna, ele segue para o Norte e Sul.',56,67,0,0,0,0,0,0,0,'.n/.s/'),(58,'Cavernas','Você está em uma bifurcação nas cavernas. A Leste há um túnel. A Caverna segue a Oeste.',0,0,56,60,0,0,0,0,0,'.l/.o/'),(59,'Cavernas','Você está em uma bifurcação nas cavermas. Há um túnel a Oeste.',0,0,0,56,0,0,0,0,0,'.o/'),(60,'Cavernas','Você está em uma bifurcação nas cavernas, há uma saída para leste. A oeste você vê uma área maior das Cavernas.',0,0,58,61,0,0,0,0,0,'.l/.o/'),(61,'Cavernas','Você está em uma area aberta dentro das Cavernas, há saídas para Norte, Sul e Oeste. Ao leste você vê uma leve luz vindo da esquerda.',62,65,60,64,0,0,0,0,0,'.n/.s/.l/.o/'),(62,'Cavernas','Você está no canto da Caverna que segue para o Sul e Oeste.',0,61,0,63,0,0,0,0,0,'.s/.o/'),(63,'Cavernas','Você está em um canto da Caverna que segue para Leste e Sul.',0,64,62,0,0,0,0,0,0,'.s/.l/'),(64,'Cavernas','Você está em uma área aberta da Caverna que segue para Norte, Sul e Leste.',63,66,61,0,0,0,0,0,0,'.n/.s/.l/'),(65,'Cavernas','Você está em um canto da caverna, há saídas para o Norte e Oeste',61,0,0,66,0,0,0,0,0,'.n/.o/'),(66,'Cavernas','Você está no canto da caverna, há saídas para o Norte e Leste.',64,0,65,0,0,0,0,0,0,'.n/.l/'),(67,'Tuneis','Você está em uma espécie de Tunel exculpido nas paredes da caverma, ele segue para Norte e Sul. A caverna se divide a Leste e Oeste.',57,70,68,69,0,0,0,0,0,'.n/.s/.l/.o/'),(68,'Caverna','Você está em uma bifurcação nas cavernas. Ao oeste há um túnel',0,0,0,67,0,0,0,0,0,'.o/'),(69,'Cavernas','Você está em uma bifurcação nas cavernas. Ao leste há um túnel.',0,0,67,0,0,0,0,0,0,'.l/'),(70,'Tuneis','Você está no final dos túneis, ele segue para o Norte. Ao Sul há um enorme desfiladeiro. Há uma corda amarrada por onde você pode conseguir descer.',67,71,0,0,0,0,0,0,0,'.n/.s/'),(71,'Cavernas','Você está em uma area remota das cavernas. Há uma corda ao Norte que leva até os túneis. A caverna segue a Leste, Oeste e Sul',70,77,72,73,0,0,0,0,0,'.n/.s/.l/.o/'),(72,'Cavernas','Você está em uma area remota das cavernas.',0,74,0,71,0,0,0,0,0,'.s/.o/'),(73,'Cavernas','Você está em uma area remota das cavernas.',0,78,71,0,0,0,0,0,0,'.s/.l/'),(74,'Cavernas','Você está em uma area remota das cavernas.',72,0,75,77,0,0,0,0,0,'.n/.l/.o/'),(75,'Cavernas','Você está em uma area remota das cavernas.',0,0,76,74,0,0,0,0,0,'.l/.o/'),(76,'Cavernas','Você está em uma area remota das cavernas.',0,0,0,75,0,0,0,0,0,'.o/'),(77,'Cavernas','Você está em uma area remota das cavernas.',71,0,74,78,0,0,0,0,0,'.n/.l/.o/'),(78,'Cavernas','Você está em uma area remota das cavernas.',73,0,77,0,0,0,0,0,0,'.n/.l/'),(79,'Floresta','Você está rodeado de árvores por todos os lados.',83,27,81,80,0,0,0,0,0,'.n/.s/.l/.o/'),(80,'Floresta','Você está rodeado de árvores por todos os lados.',82,28,79,0,0,0,0,0,0,'.n/.s/.l/'),(81,'Floresta','Você está rodeado de árvores por todos os lados.',0,23,0,79,0,0,0,0,0,'.s/.o/'),(82,'Floresta','Você está rodeado de árvores por todos os lados.',0,80,83,0,0,0,0,0,0,'.s/.l/'),(83,'Floresta','Você está rodeado de árvores por todos os lados.',86,79,84,82,0,0,0,0,0,'.n/.s/.l/.o/'),(84,'Floresta','Você está rodeado de árvores por todos os lados.',87,81,85,83,0,0,0,0,0,'.n/.s/.l/.o/'),(85,'Floresta','Você está rodeado de árvores por todos os lados.',88,0,0,84,0,0,0,0,0,'.n/.o/'),(86,'Floresta','Você está rodeado de árvores por todos os lados.',0,83,87,0,0,0,0,0,0,'.s/.l/'),(87,'Floresta','Você está rodeado de árvores por todos os lados.',91,84,88,86,0,0,0,0,0,'.n/.s/.l/.o/'),(88,'Floresta','Você está rodeado de árvores por todos os lados.',92,85,89,87,0,0,0,0,0,'.n/.s/.l/.o/'),(89,'Floresta','Você está rodeado de árvores por todos os lados.',93,0,90,88,0,0,0,0,0,'.n/.l/.o/'),(90,'Floresta','Você está rodeado de árvores por todos os lados.',94,95,0,89,0,0,0,0,0,'.n/.s/.o/'),(91,'Floresta','Você está rodeado de árvores por todos os lados.',0,87,92,0,0,0,0,0,0,'.s/.l/'),(92,'Floresta','Você está rodeado de árvores por todos os lados.',0,88,93,91,0,0,0,0,0,'.s/.l/.o/'),(93,'Floresta','Você está rodeado de árvores por todos os lados.',0,89,94,92,0,0,0,0,0,'.s/.l/.o/'),(94,'Floresta','Você está rodeado de árvores por todos os lados.',0,90,0,93,0,0,0,0,0,'.s/.o/'),(95,'Estrada Secundária','Você está em uma pequena estradinha atrás do vilarejo',90,0,0,0,0,0,0,0,0,'.n/'),(96,'Vilarejo','Você está em um pequeno vilarejo próximo a cidade ',0,19,97,0,0,0,0,0,0,'.s/.l/'),(97,'Vilarejo','Você está em um pequeno vilarejo próximo a cidade ',95,0,0,96,0,0,0,0,0,'.n/.o/'),(98,'Campos','Você está em um campo aberto',0,99,102,35,0,0,0,0,0,'.s/.l/.o/'),(99,'Campos','Você está em um campo aberto',98,100,103,36,0,0,0,0,0,'.n/.s/.l/.o/'),(100,'Campos','Você está em um campo aberto',99,101,104,0,0,0,0,0,0,'.n/.s/.l/'),(101,'Campos','Você está em um campo aberto',100,0,105,0,0,0,0,0,0,'.n/.l/'),(102,'Campos','Você está em um campo aberto',0,103,106,98,0,0,0,0,0,'.s/.l/.o/'),(103,'Campos','Você está em um campo aberto',102,104,107,99,0,0,0,0,0,'.n/.s/.l/.o/'),(104,'Campos','Você está em um campo aberto',103,105,108,100,0,0,0,0,0,'.n/.s/.l/.o/'),(105,'Campos','Você está em um campo aberto',104,0,109,101,0,0,0,0,0,'.n/.l/.o/'),(106,'Campos','Você está em um campo aberto',0,107,110,102,0,0,0,0,0,'.s/.l/.o/'),(107,'Campos','Você está em um campo aberto',106,108,111,103,0,0,0,0,0,'.n/.s/.l/.o/'),(108,'Campos','Você está em um campo aberto',107,109,112,104,0,0,0,0,0,'.n/.s/.l/.o/'),(109,'Campos','Você está em um campo aberto',108,0,113,105,0,0,0,0,0,'.n/.l/.o/'),(110,'Campos','Você está em um campo aberto',0,111,114,106,0,0,0,0,0,'.s/.l/.o/'),(111,'Campos','Você está em um campo aberto',110,112,0,107,0,0,0,0,0,'.n/.s/.o/'),(112,'Campos','Você está em um campo aberto',111,113,0,108,0,0,0,0,0,'.n/.s/.o/'),(113,'Docas','Você está nas Docas',112,0,0,109,0,0,0,0,0,'.n/.o/'),(114,'Docas','Você está nas Docas',115,0,0,110,0,0,0,0,0,'.n/.o/'),(115,'Docas','Você está nas Docas',0,114,0,0,0,0,0,0,0,'.s/');
/*!40000 ALTER TABLE `tb_area` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_comando`
--

LOCK TABLES `tb_comando` WRITE;
/*!40000 ALTER TABLE `tb_comando` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_comando` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_comando_area`
--

LOCK TABLES `tb_comando_area` WRITE;
/*!40000 ALTER TABLE `tb_comando_area` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_comando_area` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_criatura`
--

LOCK TABLES `tb_criatura` WRITE;
/*!40000 ALTER TABLE `tb_criatura` DISABLE KEYS */;
INSERT INTO `tb_criatura` VALUES (1,'Inseto',30,7,3,5,5,0,0,0,0,5,0),(2,'Inseto Venenoso',40,8,4,8,5,0,0,0,0,10,0),(3,'Rato',60,10,6,7,7,0,0,0,0,10,30),(4,'Ratazana Medonha',70,12,9,7,7,0,0,0,0,15,30),(5,'Aranha',75,11,7,9,8,0,0,0,0,20,60),(6,'Aranha Venenosa',75,14,8,10,8,0,0,0,0,30,80),(7,'Lobo',90,16,10,9,10,0,0,0,0,35,0),(8,'Lobo Raivoso',100,18,10,10,12,0,0,0,0,50,0),(9,'Morcego',60,12,7,8,8,0,0,0,0,30,0),(10,'Troll',120,20,13,12,15,0,0,0,0,65,150),(11,'Campeão Troll',160,28,26,28,24,0,0,0,0,250,250),(12,'Goblin',120,22,12,14,12,0,0,0,0,65,100),(13,'Goblin de Atiradeira',100,24,10,14,14,0,0,0,0,65,100),(14,'Tarantula',180,27,22,21,20,0,0,0,0,70,200),(15,'Aranha Gigantesca',300,60,54,52,50,0,0,0,0,1000,1000),(16,'Goblin Enfurecido',120,32,8,14,18,0,0,0,0,75,100),(17,'Rei Goblin',200,42,32,30,34,0,0,0,0,350,100),(18,'Guarda Goblin',140,33,32,30,30,0,0,0,0,150,100),(19,'Goblin Shaman',140,36,18,32,24,0,0,0,0,180,200),(20,'Rainha Aracnídea',400,80,68,62,62,0,0,0,0,3000,1500),(21,'Minotauro',140,44,34,28,32,0,0,0,0,200,160),(22,'Minotauro Arqueiro',140,48,28,30,36,0,0,0,0,230,100),(23,'Minotauro Guardião',160,54,42,28,36,0,0,0,0,250,180),(24,'Herói Minotauro',180,58,50,34,40,0,0,0,0,300,200),(25,'Orc',120,38,40,30,34,0,0,0,0,180,200),(26,'Orc Guerreiro',120,44,40,32,36,0,0,0,0,200,200),(27,'Orc Feiticeiro',120,36,40,38,48,0,0,0,0,160,200),(28,'Campeão Orc',140,52,44,40,42,0,0,0,0,230,250),(29,'Anão',120,18,28,18,24,0,0,0,0,85,100),(30,'Anão Minerador',120,24,30,20,28,0,0,0,0,100,300),(31,'Soldado Anão',140,32,34,28,30,0,0,0,0,170,200),(32,'Guerreiro Anão',140,38,36,32,34,0,0,0,0,200,200),(33,'Milfgird',160,54,50,56,58,0,0,0,0,1500,500),(34,'Nilfgard',160,54,50,56,58,0,0,0,0,1500,500),(35,'Serpente',80,20,12,14,14,0,0,0,0,45,0),(36,'Serpente Venenosa',95,28,18,20,20,0,0,0,0,65,0),(37,'Verme',100,26,22,18,14,0,0,0,0,70,0),(38,'Escorpião',95,28,22,24,26,0,0,0,0,100,0);
/*!40000 ALTER TABLE `tb_criatura` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_deposito`
--

LOCK TABLES `tb_deposito` WRITE;
/*!40000 ALTER TABLE `tb_deposito` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_deposito` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_efeito_item`
--

LOCK TABLES `tb_efeito_item` WRITE;
/*!40000 ALTER TABLE `tb_efeito_item` DISABLE KEYS */;
INSERT INTO `tb_efeito_item` VALUES (1,97,'A',10,5);
/*!40000 ALTER TABLE `tb_efeito_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_etapa_quest`
--

LOCK TABLES `tb_etapa_quest` WRITE;
/*!40000 ALTER TABLE `tb_etapa_quest` DISABLE KEYS */;
INSERT INTO `tb_etapa_quest` VALUES (1,1,'A jornada do iniciante',0,1,0,0,0,'I','Pegue o pergaminho no altar do Templo e entregue para a druida Anita.\nPara pegar um item, utilize o comando .get em seguida informe o item que deseja pegar.'),(2,2,'A hora do combate',0,0,0,0,3,'C','Converse com o Carlos no Depósito e em seguida retorne para falar com Bruno.'),(3,3,'Batalhando',0,0,1,1,0,'H','Enfrente o Inseto que está importunando o Bruno, em seguida reporte a ele o seu resultado.'),(4,4,'Infestação de Ratos',0,0,50,3,0,'H','Elimine os ratos que vivem na rede de esgotos da cidade para evitar uma infestação.'),(5,5,'Infestação de Ratos',0,94,0,0,0,'I','Faça uma Poção Inseticida e entregue para Diana na Estalagem');
/*!40000 ALTER TABLE `tb_etapa_quest` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_forja`
--

LOCK TABLES `tb_forja` WRITE;
/*!40000 ALTER TABLE `tb_forja` DISABLE KEYS */;
INSERT INTO `tb_forja` VALUES (1,35,34,0,0,0,0,5,0,0,0,0,'F','F',11),(2,36,35,0,0,0,0,3,0,0,0,0,'F','F',11),(3,37,44,35,39,0,0,1,10,2,0,0,'M','F',11),(4,38,37,35,39,0,0,1,35,5,0,0,'D','F',11),(5,44,12,35,39,0,0,1,3,1,0,0,'F','F',11),(6,63,40,0,0,0,0,1,0,0,0,0,'D','F',11),(7,42,45,34,0,0,0,1,2,0,0,0,'F','F',11),(8,43,45,0,0,0,0,3,0,0,0,0,'F','F',11),(9,58,61,0,0,0,0,2,0,0,0,0,'D','F',11),(10,94,24,29,95,0,0,1,5,1,0,0,'D','A',20),(11,97,24,31,32,0,0,1,5,1,0,0,'M','A',20);
/*!40000 ALTER TABLE `tb_forja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_habilidade`
--

LOCK TABLES `tb_habilidade` WRITE;
/*!40000 ALTER TABLE `tb_habilidade` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_habilidade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_habilidade_personagem`
--

LOCK TABLES `tb_habilidade_personagem` WRITE;
/*!40000 ALTER TABLE `tb_habilidade_personagem` DISABLE KEYS */;
/*!40000 ALTER TABLE `tb_habilidade_personagem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_inventario`
--

LOCK TABLES `tb_inventario` WRITE;
/*!40000 ALTER TABLE `tb_inventario` DISABLE KEYS */;
INSERT INTO `tb_inventario` VALUES (21,4,28,'   '),(45,4,28,'   '),(46,4,30,'   '),(48,4,30,'   '),(50,4,28,'   '),(51,4,8,''),(53,4,26,'[4]'),(54,4,25,'[5]'),(55,4,5,'[2]'),(56,4,35,'   '),(57,4,46,'   '),(59,5,3,'[4]'),(60,5,4,'[5]'),(67,5,8,'[2]'),(97,6,24,'   '),(109,2,52,''),(118,2,13,''),(119,2,24,''),(121,2,24,''),(122,2,24,''),(123,2,24,''),(124,2,24,''),(126,2,24,''),(127,2,24,''),(134,7,27,''),(144,7,23,'[1]'),(145,7,7,'[2]'),(164,7,26,'[4]'),(166,7,25,'[5]'),(175,4,31,''),(190,7,29,'   '),(191,7,29,'   '),(192,7,29,'   '),(193,7,29,'   '),(194,7,30,'   '),(195,7,30,'   '),(199,7,29,'   '),(202,8,4,'[5]'),(214,8,5,'[2]'),(251,8,26,'[4]'),(252,8,23,'[1]'),(253,8,27,''),(254,8,27,''),(255,8,27,''),(256,8,27,''),(257,8,27,''),(258,2,98,''),(260,2,46,NULL),(261,2,46,NULL),(264,2,46,NULL),(268,2,101,''),(269,2,102,''),(270,2,103,''),(272,2,46,NULL),(275,2,46,NULL),(276,2,46,NULL),(284,2,46,NULL),(288,2,46,NULL),(290,2,46,NULL),(292,2,46,NULL),(295,2,47,NULL),(301,2,47,NULL),(303,2,46,NULL),(306,2,46,NULL),(307,2,46,NULL),(308,2,47,NULL),(313,2,46,NULL),(314,2,48,NULL),(318,2,46,NULL),(320,2,47,NULL),(324,2,48,NULL),(328,2,48,NULL),(334,2,34,NULL),(337,2,35,''),(338,2,35,''),(339,2,35,''),(340,2,35,''),(341,2,35,''),(342,2,35,''),(343,2,35,''),(344,2,35,''),(353,6,8,'[2]'),(354,6,25,'[5]'),(357,6,23,'[1]'),(374,6,27,''),(375,6,27,''),(376,6,27,''),(377,6,27,''),(378,6,24,''),(380,6,26,'[4]'),(381,6,27,'   '),(383,6,41,''),(384,6,24,''),(385,6,24,''),(386,6,24,''),(387,6,24,''),(388,6,24,''),(389,6,24,''),(390,6,24,''),(395,6,24,''),(396,6,24,''),(397,6,96,'   '),(398,6,35,'   '),(400,6,24,''),(401,6,24,''),(402,6,35,'   '),(403,6,24,''),(404,6,24,''),(405,6,24,''),(407,2,90,'[2]'),(408,2,99,'   '),(409,2,100,'   '),(410,2,3,'[4]'),(411,2,4,'[5]');
/*!40000 ALTER TABLE `tb_inventario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_item`
--

LOCK TABLES `tb_item` WRITE;
/*!40000 ALTER TABLE `tb_item` DISABLE KEYS */;
INSERT INTO `tb_item` VALUES (1,'Pergaminho do Iniciante',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ','Você vê um pequeno pergaminho. Há uma sigla escrita em letras garrafais: \"N. O. O. B.\"',NULL,NULL),(2,'Espada de Madeira',1,0,0,0,0,0,0,0,0,0,3,'W',0,'S','Você vê uma espada entalhada em madeira.',NULL,NULL),(3,'Armadura de Couro Leve',0,1,0,0,0,0,0,0,0,0,0,'A',0,' ','Você vê uma armadura feita de couro',NULL,NULL),(4,'Bota de Couro Leve',0,1,0,0,0,0,0,0,0,0,0,'B',0,' ','Você vê uma bota feita de couro',NULL,NULL),(5,'Adaga',1,0,0,1,0,0,0,0,0,0,7,'W',3,'S','Você vê uma pequena Adaga pontiaguda.',NULL,NULL),(6,'Bastão',1,1,0,0,0,0,0,0,0,0,5,'W',3,'C','Você vê um bastão. Parece ter sido feito sobre um pedaço de madeira bem pesado.',NULL,NULL),(7,'Lança',1,0,1,0,0,0,0,0,0,0,7,'W',3,'D','Você vê uma Lança comprida afiada na ponta.',NULL,NULL),(8,'Machadinha',2,0,0,0,0,0,0,0,0,0,9,'W',3,'A','Você vê uma machadinha. Sua lâmida parece muito afiada.',NULL,NULL),(9,'Arco e Flecha',1,0,3,0,0,0,0,0,0,0,15,'W',5,'D','Você vê um arco e flecha',NULL,NULL),(10,'Clava',2,2,0,0,0,0,0,0,0,0,12,'W',5,'C',NULL,NULL,NULL),(11,'Machado Leve',4,0,0,0,0,0,0,0,0,0,14,'W',5,'A','Você vê um machado leve',NULL,NULL),(12,'Espada Leve',2,0,0,2,0,0,0,0,0,0,12,'W',5,'S','Você vê uma espada leve. Muito boa de manusear.',NULL,NULL),(13,'Machado de Ferro',10,0,0,0,0,0,0,0,0,0,34,'W',10,'A',NULL,NULL,NULL),(14,'Espada Curta',6,0,0,5,0,0,0,0,0,0,32,'W',10,'S','Você vê uma espada curta.',NULL,NULL),(15,'Espada Longa',9,0,0,8,0,0,0,0,0,0,42,'W',20,'S','Você vê uma espada de lâmina longa.',NULL,NULL),(16,'Lança de Ferro',5,0,6,0,0,0,0,0,0,0,34,'W',10,'D',NULL,NULL,NULL),(17,'Machado Duplo',18,0,0,0,0,0,0,0,0,0,48,'W',20,'A',NULL,NULL,NULL),(18,'Katana',15,0,0,10,0,0,0,0,0,0,65,'W',30,'S','Você vê uma espada com a lamina ondular',NULL,NULL),(19,'Martelo de Guerra',7,8,0,0,0,0,0,0,0,0,32,'W',15,'C',NULL,NULL,NULL),(20,'Arco Galvânico',9,0,8,0,0,0,0,0,0,0,34,'W',15,'D',NULL,NULL,NULL),(21,'Arco Leve',6,0,6,0,0,0,0,0,0,0,30,'W',10,'D',NULL,NULL,NULL),(22,'Arco Real',17,0,8,0,0,0,0,0,0,0,75,'W',30,'D',NULL,NULL,NULL),(23,'Capacete de Couro Leve',0,2,0,0,0,0,0,0,0,0,0,'C',3,' ','Você vê um capacete feito de couro.',NULL,NULL),(24,'Recipiente Vazio',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ','Você vê um recipiente vazio.',NULL,NULL),(25,'Bota de Couro Reforçada',0,3,0,0,0,0,0,0,0,0,0,'B',3,' ','Você vê um par de Botas de couro. Parece bem reforçado.',NULL,NULL),(26,'Armadura de Couro Reforçada',0,4,0,0,0,0,0,0,0,0,0,'A',5,' ','Você vê uma armadura feita de couro. Parece bem Reforçado.',NULL,NULL),(27,'Poção de Cura Pequena',0,0,0,0,0,0,0,0,30,0,0,'I',0,' ','Você vê um recipiente cheio de um líquido avermelhado.',NULL,NULL),(28,'Asa de Inseto',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ','Você vê a asa de um inseto.',NULL,NULL),(29,'Rabo de Rato',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ','Você vê o rabo de um rato',NULL,NULL),(30,'Perna de Aranha',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ','Você vê a perna de uma aranha',NULL,NULL),(31,'Pelo de Lobo',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ','Você vê um pelo de lobo',NULL,NULL),(32,'Dente de Lobo',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ','Você vê um dente de lobo',NULL,NULL),(33,'Asa de Morcego',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ','Você vê a asa de um morcego',NULL,NULL),(34,'Pedaço de Ferro',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ','Você vê um pedaço de ferro quebrado',NULL,NULL),(35,'Barra de Ferro',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ','Você vê uma barra de ferro',NULL,NULL),(36,'Adaga Forjada',1,0,0,1,0,0,0,0,0,0,9,'W',3,'S','Você vê uma pequena Adaga pontiaguda. Ela parece ter diso forjada pessoalmente. Por isso parece ser melhor do que uma adaga comum.',NULL,NULL),(37,'Espada Leve Melhorada',5,0,0,5,0,0,0,0,0,0,28,'W',10,'S','Você vê uma Espada Leve. Ela parece ter sido melhorada pelas mãos de um artesão.',NULL,NULL),(38,'Espada Leve Perfeita',10,0,0,8,0,0,0,0,0,0,45,'W',25,'S','Você vê uma Espada Leve. Ela está em perfeitas condições. Um trabalho de forja magnífico.',NULL,NULL),(39,'Aço',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ','Você vê um pedaço de aço detorcido',NULL,NULL),(40,'Carvalho',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ','Você vê um pedaço de madeira de Carvalho. Parece muito resistente.',NULL,NULL),(41,'Bastão Forjado',1,2,0,0,0,0,0,0,0,0,6,'W',3,'C','Você vê um bastão. Ele parece ter sido forjado sobre um pedaço de madeira de Carvalho muito resistente.',NULL,NULL),(42,'Machadinha Forjada',2,0,0,0,0,0,0,0,0,0,12,'W',3,'A','Você vê uma machadinha. Ela parece ter sido forjada pessoalmente. Sua lâmina parece melhor do que uma machadinha comum.',NULL,NULL),(43,'Lança Forjada',1,0,2,0,0,0,0,0,0,0,7,'W',3,'D','Você vê uma lança comprida e afiada na ponta. Ela parece ter sido forjada pessoalmente, por isso parece melhor do que uma lança comum.',NULL,NULL),(44,'Espada Leve Forjada',3,0,0,2,0,0,0,0,0,0,15,'W',5,'S','Você vê uma espada leve. Muito boa de manusear. Ela foi forjada pessoalmente, por isso parece melhor do que uma espada leve comum.',NULL,NULL),(45,'Pedaço de Madeira',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ','Você vê um pedaço de madeira em perfeitas condições.',NULL,NULL),(46,'Pepita de Prata',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ',' ',NULL,NULL),(47,'Pepita de Ouro',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ',' ',NULL,NULL),(48,'Pedra de Diamante',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ',' ',NULL,NULL),(49,'Diamante',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ',' ',NULL,NULL),(50,'Barra de Ouro',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ',' ',NULL,NULL),(51,'Barra de Prata',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ',' ',NULL,NULL),(52,'Machado Leve Forjado',5,0,0,0,0,0,0,0,0,0,18,'W',5,'A',NULL,NULL,NULL),(53,'Machado Leve Melhorado',9,0,0,0,0,0,0,0,0,0,32,'W',10,'A',NULL,NULL,NULL),(54,'Machado Leve Perfeito',18,0,0,0,0,0,0,0,0,0,62,'W',25,'A',NULL,NULL,NULL),(55,'Machado de Ferro Forjado',14,0,0,0,0,0,0,0,0,0,40,'W',15,'A',NULL,NULL,NULL),(56,'Machado de Ferro Melhorado',16,0,0,0,0,0,0,0,0,0,45,'W',25,'A',NULL,NULL,NULL),(57,'Machado de Ferro Perfeito',22,0,0,0,0,0,0,0,0,0,68,'W',30,'A',NULL,NULL,NULL),(58,'Machado dos Anões',25,0,0,0,0,0,0,0,0,0,72,'W',30,'A',NULL,NULL,NULL),(59,'Arco Forjado',3,0,4,0,0,0,0,0,0,0,25,'W',7,'D',NULL,NULL,NULL),(60,'Arco Melhorado',8,0,6,0,0,0,0,0,0,0,32,'W',10,'D',NULL,NULL,NULL),(61,'Arco Perfeito',10,0,8,0,0,0,0,0,0,0,47,'W',25,'D',NULL,NULL,NULL),(62,'Fragmento de Machado dos Anões',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ','Você vê um fragmento de um grande machado',NULL,NULL),(63,'Clava Forjada',2,3,0,0,0,0,0,0,0,0,15,'W',5,'C',NULL,NULL,NULL),(64,'Maça',5,5,0,0,0,0,0,0,0,0,30,'W',10,'C',NULL,NULL,NULL),(65,'Maça Forjada',5,6,0,0,0,0,0,0,0,0,32,'W',10,'C',NULL,NULL,NULL),(66,'Maça Melhorada',8,8,0,0,0,0,0,0,0,0,35,'W',15,'C',NULL,NULL,NULL),(67,'Maça Perfeita',10,10,0,0,0,0,0,0,0,0,40,'W',20,'C',NULL,NULL,NULL),(68,'Martelo Gigante',8,12,0,0,0,0,0,0,0,0,55,'D',25,'C',NULL,NULL,NULL),(69,'Martelo de Onyx',10,15,0,0,0,0,0,0,0,0,60,'D',30,'C',NULL,NULL,NULL),(70,'Capacete de Ferro',0,4,0,0,0,0,0,0,0,0,0,'C',5,' ',NULL,NULL,NULL),(71,'Chapéu de Bruxo',0,0,0,0,2,0,2,0,0,0,0,'C',5,' ',NULL,NULL,NULL),(72,'Bandana',0,1,1,0,0,0,0,0,0,0,0,'C',3,' ',NULL,NULL,NULL),(73,'Capuz',0,0,0,2,0,0,0,0,0,0,0,'C',3,' ',NULL,NULL,NULL),(74,'Capacete de Bronze',0,10,0,0,0,0,0,0,0,0,0,'C',10,' ',NULL,NULL,NULL),(75,'Capacete de Prata',0,12,0,0,0,0,0,0,0,0,0,'C',15,' ',NULL,NULL,NULL),(76,'Capacete de Ouro',0,16,0,0,0,0,0,0,0,0,0,'C',20,' ',NULL,NULL,NULL),(77,'Capacete Real',0,30,0,0,0,0,0,0,0,0,0,'C',50,' ',NULL,NULL,NULL),(78,'Capacete de Onyx',0,22,0,0,0,0,0,0,0,0,0,'C',30,' ',NULL,NULL,NULL),(79,'Capa',0,0,0,0,2,0,0,2,0,0,0,'A',5,' ',NULL,NULL,NULL),(80,'Armadura de Ferro',0,10,0,0,0,0,0,0,0,0,0,'A',10,' ',NULL,NULL,NULL),(81,'Armadura de Aço',0,12,0,0,0,0,0,0,0,0,0,'A',12,' ',NULL,NULL,NULL),(82,'Armadura de Prata',0,15,0,0,0,0,0,0,0,0,0,'A',15,' ',NULL,NULL,NULL),(83,'Armadura de Ouro',0,20,0,0,0,0,0,0,0,0,0,'A',20,' ',NULL,NULL,NULL),(84,'Armadura de Onix',0,25,0,0,0,0,0,0,0,0,0,'A',25,' ',NULL,NULL,NULL),(85,'Armadura Real',0,30,0,0,0,0,0,0,0,0,0,'A',30,' ',NULL,NULL,NULL),(86,'Sandálias',0,1,0,0,0,0,0,1,0,0,0,'B',5,' ',NULL,NULL,NULL),(87,'Bota de Ferro',0,12,0,0,0,0,0,0,0,0,0,'B',10,' ',NULL,NULL,NULL),(88,'Bota de Ouro',0,20,0,0,0,0,0,0,0,0,0,'B',25,' ',NULL,NULL,NULL),(89,'Botas Leves',0,0,8,0,0,0,0,0,0,0,0,'B',5,' ',NULL,NULL,NULL),(90,'Cajado de Onyx',0,0,0,0,12,0,0,0,0,0,30,'W',10,'M',NULL,NULL,NULL),(91,'Poção de Mana Pequena',0,0,0,0,0,0,0,0,0,30,0,'I',0,' ',NULL,NULL,NULL),(92,'Cajado',0,0,0,0,12,0,0,10,0,0,0,'W',5,'M',NULL,NULL,NULL),(93,'Cajado Mágico',0,0,0,0,18,0,0,14,0,0,0,'W',15,'M',NULL,NULL,NULL),(94,'Poção Inseticida',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ',NULL,NULL,NULL),(95,'Veneno de Aranha',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ',NULL,NULL,NULL),(96,'Pele de Troll',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ',NULL,NULL,NULL),(97,'Poção de Força',0,0,0,0,0,0,0,0,0,0,0,'I',0,' ',NULL,NULL,NULL),(98,'Picareta',0,0,0,0,0,0,0,0,0,0,0,'W',0,'P',NULL,10,0),(99,'Picareta de Ferro',0,0,0,0,0,0,0,0,0,0,0,'W',0,'P',NULL,7,5),(100,'Picareta de Prata',0,0,0,0,0,0,0,0,0,0,0,'W',0,'P',NULL,5,10),(101,'Picareta de Ouro',0,0,0,0,0,0,0,0,0,0,0,'W',0,'P',NULL,5,15),(102,'Picareta de Diamante',0,0,0,0,0,0,0,0,0,0,0,'W',0,'P',NULL,3,20),(103,'Picareta de Onyx',0,0,0,0,0,0,0,0,0,0,0,'W',0,'P',NULL,1,30),(104,'Pepita de Onyx',0,0,0,0,0,0,0,0,0,0,0,'M',0,' ',NULL,NULL,NULL);
/*!40000 ALTER TABLE `tb_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_item_area`
--

LOCK TABLES `tb_item_area` WRITE;
/*!40000 ALTER TABLE `tb_item_area` DISABLE KEYS */;
INSERT INTO `tb_item_area` VALUES (119,3,2),(143,35,30),(155,8,2),(164,53,29),(190,47,29),(194,43,29),(195,46,29),(196,53,29),(197,53,29),(198,8,2),(208,24,28),(215,109,24),(219,109,46),(220,109,46),(221,109,34);
/*!40000 ALTER TABLE `tb_item_area` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_loja`
--

LOCK TABLES `tb_loja` WRITE;
/*!40000 ALTER TABLE `tb_loja` DISABLE KEYS */;
INSERT INTO `tb_loja` VALUES (1,5,8,40,100,5),(2,6,8,40,100,6),(3,7,8,40,100,7),(4,8,8,40,100,8),(5,3,8,10,40,3),(6,4,8,10,40,4),(7,23,8,80,200,9),(8,26,8,200,500,10),(9,25,8,200,500,11),(10,24,8,5,10,1),(11,27,8,15,45,2),(12,28,3,10,500,1),(13,29,3,10,500,2),(14,30,3,15,800,3),(15,31,3,20,1000,4),(16,32,3,100,5000,6),(17,33,3,20,1000,5),(18,34,11,100,250,1),(19,46,11,400,1000,2),(20,47,11,1000,2500,4),(21,48,11,2000,5000,5),(22,35,11,600,1500,3),(23,104,11,10000,25000,6);
/*!40000 ALTER TABLE `tb_loja` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_loot`
--

LOCK TABLES `tb_loot` WRITE;
/*!40000 ALTER TABLE `tb_loot` DISABLE KEYS */;
INSERT INTO `tb_loot` VALUES (1,1,28,1,20000),(2,2,28,1,30000),(3,3,29,1,15000),(4,4,29,1,25000),(5,5,30,1,28000),(6,6,30,1,35000),(7,7,31,1,20000),(8,8,31,2,30000),(9,8,32,1,10000),(10,9,33,2,40000),(11,10,45,1,20000),(12,11,45,2,60000),(13,11,40,1,40000),(14,29,34,1,20000),(15,29,35,1,5000),(16,29,46,1,500),(17,30,34,1,40000),(18,30,35,1,20000),(19,30,46,1,10000),(20,30,47,1,5000),(21,33,62,1,40000),(22,34,62,1,40000),(23,6,95,1,5000),(24,10,10,1,5000),(25,10,96,1,20000),(26,11,96,2,50000),(27,30,98,1,10000),(28,11,25,1,40000),(29,11,26,1,40000),(30,11,64,1,20000);
/*!40000 ALTER TABLE `tb_loot` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_mina`
--

LOCK TABLES `tb_mina` WRITE;
/*!40000 ALTER TABLE `tb_mina` DISABLE KEYS */;
INSERT INTO `tb_mina` VALUES (1,1,34,5000),(2,1,46,2000),(3,1,47,1000),(4,1,48,600),(5,1,104,300);
/*!40000 ALTER TABLE `tb_mina` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_npc`
--

LOCK TABLES `tb_npc` WRITE;
/*!40000 ALTER TABLE `tb_npc` DISABLE KEYS */;
INSERT INTO `tb_npc` VALUES (1,'Anita, a druída',1),(2,'Bruno, o guerreiro',2),(3,'Carlos, oficial do depósito',9),(4,'Diana, dona da estalagem',7),(5,'Elena, a garçonete',7),(6,'Francis, o Guarda',6),(7,'Gabriela, a Arqueira',19),(8,'Hugo, o Mineiro',39),(9,'Irinia, a Maga',NULL),(10,'Jeremy, o Bárbaro',NULL),(11,'Kel, o Anão',NULL),(12,'Loki, o Bobo da Corte',NULL),(13,'Melchior, o Guarda Real',NULL),(14,'Nebula, a Feiticeira',NULL),(15,'Oswald, o Costureiro',NULL),(16,'Patrick II, o Rei',NULL),(17,'Querald, o Guarda',NULL),(18,'Ruben, o Guarda',NULL),(19,'Sara, a Dama',NULL),(20,'Tormund, o Pacificador',NULL),(21,'Ursula, a menina na floresta',NULL),(22,'Vraska, a Serpente',NULL),(23,'Zoan, o Espadachim',NULL);
/*!40000 ALTER TABLE `tb_npc` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_pericia`
--

LOCK TABLES `tb_pericia` WRITE;
/*!40000 ALTER TABLE `tb_pericia` DISABLE KEYS */;
INSERT INTO `tb_pericia` VALUES (1,'Novato na luta com espadas','Aumenta o atributo de ataque em +1 quando equipado com uma espada',1,0,0,0,0,0,0,0,0,0,'V',100,2,'S','X'),(2,'Adepto da luta com espadas','Aumenta o atributo de ataque em 20% quando equipado com uma epada.',20,0,0,0,0,0,0,0,0,0,'P',1000,3,'S',' '),(3,'Experiente na luta com espadas','Aumenta o atributo de ataque em 40% quando equipado com uma epada.',40,0,0,0,0,0,0,0,0,0,'P',10000,4,'S',' '),(4,'Mestre da luta com espadas','Aumenta o atributo de ataque em 60% quando equipado com uma epada.',60,0,0,0,0,0,0,0,0,0,'P',100000,5,'S',' '),(5,'Lenda da luta com espadas','Aumenta o atributo de ataque em 100% quando equipado com uma epada.',100,0,0,0,0,0,0,0,0,0,'P',1000000,0,'S',' '),(6,'Novato na luta com martelos','Concede DEF +1 quando equipado com Martelos',0,1,0,0,0,0,0,0,0,0,'V',100,7,'M','X'),(7,'Adepto da luta com martelos','Concede DEF +10% e DES +10% quando equipado com Martelos',0,10,0,10,0,0,0,0,0,0,'P',1000,8,'M',' '),(8,'Experiente na luta com martelos','Concede DEF +30% e DES +10% quando equipado com Martelos',0,30,0,10,0,0,0,0,0,0,'P',10000,9,'M',' '),(9,'Mestre da luta com martelos','Concede DEF +50% e DES +10% quando equipado com Martelos',0,50,0,10,0,0,0,0,0,0,'P',100000,10,'M',' '),(10,'Lenda da luta com martelos','Concede DEF +80% e DES +20% quando equipado com Martelos',0,80,0,20,0,0,0,0,0,0,'P',1000000,0,'M',' '),(11,'Novato na luta com machados','Concede +5% de dano maximo quando equipado com machados',0,0,0,0,0,0,0,0,5,0,'P',100,12,'A','X'),(12,'Adepto da luta com machados','Concede +15% de dano maximo quando equipado com machados',0,0,0,0,0,0,0,0,15,0,'P',1000,13,'A',' '),(13,'Experiente na luta com machados','Concede +25% de dano maximo quando equipado com machados',0,0,0,0,0,0,0,0,25,0,'P',10000,14,'A',' '),(14,'Mestre da luta com machados','Concede +50% de dano maximo quando equipado com machados',0,0,0,0,0,0,0,0,50,0,'p',100000,15,'A',' '),(15,'Lenda da luta com machados','Concede +80% de dano maximo quando equipado com machados',0,0,0,0,0,0,0,0,80,0,'P',1000000,0,'A',' '),(16,'Novato na luta a distancia','Concede AGI+1 quando equipado com armas de ataque a distancia',0,0,1,0,0,0,0,0,0,0,'V',100,17,'D','X'),(17,'Adepto da luta a distancia','Concede AGI+15% e DES+5% quando equipado com armas de ataque a distancia',0,0,15,5,0,0,0,0,0,0,'P',1000,18,'D',' '),(18,'Experiente na luta a distancia','Concede AGI+35% e DES+5% quando equipado com armas de ataque a distancia',0,0,35,5,0,0,0,0,0,0,'P',10000,19,'D',' '),(19,'Mestre da luta a distancia','Concede AGI+55% e DES+5% quando equipado com armas de ataque a distancia',0,0,55,5,0,0,0,0,0,0,'P',100000,20,'D',' '),(20,'Lenda da luta a distancia','Concede AGI+85% e DES+15% quando equipado com armas de ataque a distancia',0,0,85,15,0,0,0,0,0,0,'P',1000000,0,'D',' '),(21,'Novato na luta com magia','Concede INT+1 quando equipado com armas magicas',0,0,0,0,1,0,0,0,0,0,'V',100,22,'M','X'),(22,'Adepto da luta com magia','Concede INT +20% e CON +5% quando equipado com armas magicas',0,0,0,0,20,0,0,5,0,0,'P',1000,23,'M',' '),(23,'Experiente na luta com magia','Concede INT +40% e CON +5% quando equipado com armas magicas',0,0,0,0,40,0,0,5,0,0,'P',10000,24,'M',' '),(24,'Mestre da luta com magia','Concede INT +55% e CON +10% quando equipado com armas magicas',0,0,0,0,55,0,0,10,0,0,'P',100000,25,'M',' '),(25,'Lenda da luta com magia','Concede INT +90% e CON +15% quando equipado com armas magicas',0,0,0,0,90,0,0,15,0,0,'P',1000000,0,'M',' ');
/*!40000 ALTER TABLE `tb_pericia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_pericia_personagem`
--

LOCK TABLES `tb_pericia_personagem` WRITE;
/*!40000 ALTER TABLE `tb_pericia_personagem` DISABLE KEYS */;
INSERT INTO `tb_pericia_personagem` VALUES (5,4,2,999,'O'),(6,4,3,31,'X'),(7,5,1,25,'X'),(8,5,11,71,'X'),(9,6,1,92,'O'),(10,6,2,21,'X'),(11,2,11,28,'X'),(12,2,6,20,'X'),(13,7,1,54,'X'),(14,7,16,38,'X'),(15,8,1,43,'X');
/*!40000 ALTER TABLE `tb_pericia_personagem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_personagem`
--

LOCK TABLES `tb_personagem` WRITE;
/*!40000 ALTER TABLE `tb_personagem` DISABLE KEYS */;
INSERT INTO `tb_personagem` VALUES (1,'felipe','','Pol',6,1,0,100,100,65,65,30,30,5,5,5,5,5,5,5,5,0,'N','',0,0,'N'),(2,'f','f','Master',107,10,15744,21290,22999,121,355,120,120,5,5,5,5,21,15,15,5,0,'N','',0,0,'N'),(4,'teste','teste','Testonildo',7,6,4009,4370,2815,175,175,80,80,10,10,6,10,5,10,5,5,0,'N','',0,0,'N'),(5,'1','1','Uno',3,3,507,640,105,91,91,50,50,7,5,5,6,5,6,5,5,4,'N','',0,0,'N'),(6,'novo','novo','Novato',16,6,3157,4370,17330,115,115,80,80,15,5,11,15,5,5,5,5,0,'N','',0,0,'N'),(7,'a','a','Anselmo',7,6,3035,4370,904,187,187,80,80,13,7,5,13,5,11,5,5,6,'N','',0,0,'N'),(8,'noob','noob','Nelson',8,5,1980,2540,1177,105,105,70,70,13,5,13,13,5,5,5,5,0,'N','',0,0,'N');
/*!40000 ALTER TABLE `tb_personagem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_quest`
--

LOCK TABLES `tb_quest` WRITE;
/*!40000 ALTER TABLE `tb_quest` DISABLE KEYS */;
INSERT INTO `tb_quest` VALUES (1,'A jornada começa',10,50,0,1),(2,'Hora de se prepara para a batalha',50,100,2,2),(3,'Batalhando',50,100,27,3),(4,'Infestação de Ratos',200,250,0,4),(5,'Infestação de Ratos',200,250,0,5);
/*!40000 ALTER TABLE `tb_quest` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_quest_personagem`
--

LOCK TABLES `tb_quest_personagem` WRITE;
/*!40000 ALTER TABLE `tb_quest_personagem` DISABLE KEYS */;
INSERT INTO `tb_quest_personagem` VALUES (1,2,1,1,0,'','O'),(2,2,2,2,0,'','O'),(3,2,3,3,4,'','O'),(4,4,1,1,0,'','O'),(5,4,2,2,0,'','O'),(6,4,3,3,21,'','O'),(7,5,1,1,0,'','O'),(8,5,2,2,0,'','O'),(9,5,3,3,34,'','O'),(10,6,1,1,0,'','O'),(11,6,3,3,5,'','O'),(12,6,2,2,0,'','O'),(13,7,1,1,0,'','O'),(14,7,2,2,0,'','O'),(15,7,3,3,14,'','O'),(16,4,4,4,100,'','O'),(18,4,5,5,0,'','O'),(19,7,4,4,20,'',''),(20,7,5,5,0,'','O'),(21,8,1,1,0,'','O'),(22,8,2,2,0,'','O'),(23,8,3,3,12,'','O'),(24,8,5,5,0,'','O'),(25,8,4,4,50,'','O'),(26,6,5,5,0,'','O'),(27,6,4,4,50,'','O');
/*!40000 ALTER TABLE `tb_quest_personagem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `tb_respaw`
--

LOCK TABLES `tb_respaw` WRITE;
/*!40000 ALTER TABLE `tb_respaw` DISABLE KEYS */;
INSERT INTO `tb_respaw` VALUES (11,10,1,1,1,1),(12,10,2,1,1,1),(13,10,3,1,1,1),(14,10,4,1,1,1),(15,10,5,1,1,1),(16,10,6,1,1,1),(17,10,7,1,1,1),(18,10,8,1,1,1),(19,10,9,1,1,1),(20,2,1,1,1,1),(21,3,1,2,1,2),(22,4,1,2,1,2),(23,5,1,2,1,2),(24,5,2,1,3,1),(25,6,1,1,1,1),(26,6,2,2,3,2),(27,55,29,2,1,2),(28,56,29,1,1,1),(29,56,30,1,3,1),(30,57,29,2,1,2),(31,57,30,2,3,2),(32,67,30,3,3,3),(33,70,29,3,1,3),(34,70,30,3,3,3),(35,39,29,2,1,2),(36,43,3,2,1,2),(37,44,3,2,1,2),(38,45,3,2,1,2),(39,45,4,1,1,1),(40,46,3,3,1,3),(41,46,4,1,1,1),(42,10,10,1,1,1),(43,10,11,1,1,1),(44,10,12,1,1,1),(45,10,13,1,1,1),(46,10,14,1,1,1),(47,10,15,1,1,1),(48,10,16,1,1,1),(49,10,17,1,1,1),(50,10,18,1,1,1),(51,10,19,1,1,1),(52,10,20,1,1,1),(53,10,21,1,1,1),(54,10,22,1,1,1),(55,10,23,1,1,1),(56,10,24,1,1,1),(57,10,25,1,1,1),(58,10,26,1,1,1),(59,10,27,1,1,1),(60,10,28,1,1,1),(61,10,29,1,1,1),(62,10,30,1,1,1),(63,10,31,1,1,1),(64,10,32,1,1,1),(65,10,33,1,1,1),(66,10,34,1,1,1),(67,12,1,2,1,2),(68,13,1,2,1,2),(69,14,1,3,1,3),(70,15,1,2,1,2),(71,16,1,2,1,2),(72,16,2,2,1,2),(73,17,1,2,1,2),(74,17,2,2,1,2),(75,18,1,2,1,2),(76,18,2,2,1,2),(77,18,7,1,3,1),(78,21,7,2,3,2),(79,22,7,3,3,3),(80,22,8,1,5,1),(81,53,3,3,1,3),(82,53,4,2,3,2),(83,52,3,2,1,2),(84,52,4,2,3,2),(85,51,4,4,3,4),(86,54,4,4,3,4),(87,47,3,3,1,3),(88,47,4,2,3,2),(89,48,3,2,1,2),(90,48,4,3,3,3),(91,49,3,2,1,2),(92,49,4,2,3,2),(93,50,4,3,3,3),(94,32,5,3,1,3),(95,33,5,3,1,3),(96,33,6,1,3,1),(97,34,5,2,1,2),(98,34,6,2,3,2),(99,35,6,3,3,3),(100,36,6,3,3,3),(101,37,5,2,1,2),(102,37,6,1,3,1),(103,18,5,1,1,1),(104,19,5,2,1,2),(105,34,7,1,1,1),(106,37,7,1,1,1),(107,38,7,1,1,1),(108,38,8,2,3,2),(109,40,7,2,1,2),(110,40,8,2,3,2),(111,41,8,3,3,3),(112,42,8,4,3,4),(113,24,8,2,3,2),(114,24,10,2,1,2),(115,26,10,2,1,2),(116,29,10,3,1,3),(117,30,10,3,1,3),(118,30,8,2,1,2),(119,24,11,1,2,1),(120,7,3,1,2,1),(121,98,6,2,3,2),(122,98,35,2,3,2),(123,99,35,3,3,3),(124,100,35,4,3,4),(125,101,35,4,3,4),(126,105,35,3,1,3),(127,105,36,2,1,2),(128,104,35,4,1,4),(129,103,35,4,1,4),(130,102,35,4,1,4),(131,106,37,2,3,2),(132,106,36,4,1,4),(133,107,37,4,1,3),(134,107,36,4,1,30),(135,108,38,3,1,2),(136,109,15,1,2,0);
/*!40000 ALTER TABLE `tb_respaw` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'dbconsole'
--
/*!50106 SET @save_time_zone= @@TIME_ZONE */ ;
/*!50106 DROP EVENT IF EXISTS `descanso` */;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8 */ ;;
/*!50003 SET character_set_results = utf8 */ ;;
/*!50003 SET collation_connection  = utf8_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `descanso` ON SCHEDULE EVERY 1 SECOND STARTS '2020-03-09 09:27:25' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE dbconsole.tb_personagem SET nr_hp = nr_hp + 10 WHERE nr_hp_max > nr_hp + 10 and st_descansando = 'S' */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
/*!50106 DROP EVENT IF EXISTS `descanso_max` */;;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8 */ ;;
/*!50003 SET character_set_results = utf8 */ ;;
/*!50003 SET collation_connection  = utf8_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `descanso_max` ON SCHEDULE EVERY 1 SECOND STARTS '2020-03-09 09:27:27' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE dbconsole.tb_personagem SET nr_hp = nr_hp_max WHERE nr_hp_max <= nr_hp + 10 and st_descansando = 'S' */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
/*!50106 DROP EVENT IF EXISTS `heal` */;;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8 */ ;;
/*!50003 SET character_set_results = utf8 */ ;;
/*!50003 SET collation_connection  = utf8_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `heal` ON SCHEDULE EVERY 5 SECOND STARTS '2020-03-09 09:27:22' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE dbconsole.tb_personagem SET nr_hp = nr_hp + 2 WHERE nr_hp_max > nr_hp + 2 and st_descansando = 'N' */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
/*!50106 DROP EVENT IF EXISTS `heal_max` */;;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8 */ ;;
/*!50003 SET character_set_results = utf8 */ ;;
/*!50003 SET collation_connection  = utf8_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `heal_max` ON SCHEDULE EVERY 5 SECOND STARTS '2020-03-09 09:27:23' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE dbconsole.tb_personagem SET nr_hp = nr_hp_max WHERE nr_hp_max <= nr_hp + 2 and st_descansando = 'N' */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
/*!50106 DROP EVENT IF EXISTS `remove_contador` */;;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8 */ ;;
/*!50003 SET character_set_results = utf8 */ ;;
/*!50003 SET collation_connection  = utf8_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `remove_contador` ON SCHEDULE EVERY 1 MINUTE STARTS '2020-03-12 11:14:33' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE dbconsole.tb_personagem SET nr_contaefeito = nr_contaefeito - 1 WHERE nr_contaefeito > 1 */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
/*!50106 DROP EVENT IF EXISTS `remove_efeito` */;;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8 */ ;;
/*!50003 SET character_set_results = utf8 */ ;;
/*!50003 SET collation_connection  = utf8_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `remove_efeito` ON SCHEDULE EVERY 1 MINUTE STARTS '2020-03-12 11:14:31' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE dbconsole.tb_personagem SET nr_variavel = 0, id_tipoefeito = '', nr_contaefeito = 0 WHERE nr_contaefeito = 1 */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
/*!50106 DROP EVENT IF EXISTS `respawn_1` */;;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8 */ ;;
/*!50003 SET character_set_results = utf8 */ ;;
/*!50003 SET collation_connection  = utf8_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `respawn_1` ON SCHEDULE EVERY 1 MINUTE STARTS '2020-03-09 09:26:30' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 1 */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
/*!50106 DROP EVENT IF EXISTS `respawn_10` */;;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8 */ ;;
/*!50003 SET character_set_results = utf8 */ ;;
/*!50003 SET collation_connection  = utf8_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `respawn_10` ON SCHEDULE EVERY 10 MINUTE STARTS '2020-03-09 09:26:42' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 10 */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
/*!50106 DROP EVENT IF EXISTS `respawn_12h` */;;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8 */ ;;
/*!50003 SET character_set_results = utf8 */ ;;
/*!50003 SET collation_connection  = utf8_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `respawn_12h` ON SCHEDULE EVERY 12 HOUR STARTS '2020-03-09 09:26:58' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 12 */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
/*!50106 DROP EVENT IF EXISTS `respawn_2h` */;;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8 */ ;;
/*!50003 SET character_set_results = utf8 */ ;;
/*!50003 SET collation_connection  = utf8_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `respawn_2h` ON SCHEDULE EVERY 2 HOUR STARTS '2020-03-09 09:26:56' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 2 */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
/*!50106 DROP EVENT IF EXISTS `respawn_3` */;;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8 */ ;;
/*!50003 SET character_set_results = utf8 */ ;;
/*!50003 SET collation_connection  = utf8_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `respawn_3` ON SCHEDULE EVERY 3 MINUTE STARTS '2020-03-09 09:26:33' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 3 */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
/*!50106 DROP EVENT IF EXISTS `respawn_30` */;;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8 */ ;;
/*!50003 SET character_set_results = utf8 */ ;;
/*!50003 SET collation_connection  = utf8_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `respawn_30` ON SCHEDULE EVERY 30 MINUTE STARTS '2020-03-09 09:26:45' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 30 */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
/*!50106 DROP EVENT IF EXISTS `respawn_5` */;;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8 */ ;;
/*!50003 SET character_set_results = utf8 */ ;;
/*!50003 SET collation_connection  = utf8_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `respawn_5` ON SCHEDULE EVERY 5 MINUTE STARTS '2020-03-09 09:26:35' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 5 */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
/*!50106 DROP EVENT IF EXISTS `respawn_d` */;;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8 */ ;;
/*!50003 SET character_set_results = utf8 */ ;;
/*!50003 SET collation_connection  = utf8_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`root`@`localhost`*/ /*!50106 EVENT `respawn_d` ON SCHEDULE EVERY 1 DAY STARTS '2020-03-09 09:27:00' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE dbconsole.tb_respaw SET qt_atual = qt_maximo WHERE vl_tempo = 24 */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
DELIMITER ;
/*!50106 SET TIME_ZONE= @save_time_zone */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-03-19 17:04:54
