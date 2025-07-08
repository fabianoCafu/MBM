using AutoMapper;
using SelectionMBM.CandidatoAPI.DTO;
using SelectionMBM.CandidatoAPI.Model;
using SelectionMBM.CandidatoAPI.Repository.Interface;

namespace SelectionMBM.CandidatoAPI.Repository
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private readonly IMapper _mapper;
        public readonly string _pathFileData;

        public CandidatoRepository(
            IMapper? mapper,
            IConfiguration config)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _pathFileData = config["FileSettings:CandidatoRepository"];
        }

        public bool Create(CandidatoDTO candidatoDTO)
        {
            try
            {
                var telefone = candidatoDTO.Telefone?.Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty).ToString();
                using var write = new StreamWriter(_pathFileData, true);
                var novoRegistro = $"{Guid.NewGuid()}|{candidatoDTO.Nome}|{candidatoDTO.Sexo}|{telefone}|{candidatoDTO.Email}|";
                write.WriteLine(novoRegistro);
                
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool Update(CandidatoDTO candidatoDTO)
        {
            try
            {
                var pathTemp = Path.GetFileNameWithoutExtension(_pathFileData);
                var telefone = candidatoDTO.Telefone?.Replace("(", string.Empty).Replace(")", string.Empty).Replace("-", string.Empty).Replace(" ", string.Empty).ToString();
                var registroAtualizado = $"{candidatoDTO.Id}|{candidatoDTO.Nome}|{candidatoDTO.Sexo}|{telefone}|{candidatoDTO.Email}|";

                using (var reader = new StreamReader(_pathFileData))
                {
                    using var write = new StreamWriter($"{pathTemp}.tmp"); 
                    string linha;

                    while ((linha = reader.ReadLine()) is not null)
                    {
                        if (linha.Split("|")[0].ToString() == candidatoDTO.Id.ToString())
                        {
                            write.WriteLine(registroAtualizado);
                        }
                        else
                        {
                            write.WriteLine(linha);
                        }
                    }
                }

                File.Delete(_pathFileData);
                File.Move($"{pathTemp}.tmp", _pathFileData);

                return true;
            }
            catch
            {
                return false;
            } 
        }

        public bool Delete(string id)
        {
            try
            {
                var pathTemp = Path.GetFileNameWithoutExtension(_pathFileData);

                using (var reader = new StreamReader(_pathFileData))
                {
                    using var write = new StreamWriter($"{pathTemp}.tmp");
                    string linha;

                    while ((linha = reader.ReadLine()) is not null)
                    {
                        if (!linha.Split("|")[0].ToString().Contains(id))
                        {
                            write.WriteLine(linha);
                        }
                    }
                }

                File.Delete(_pathFileData);
                File.Move($"{pathTemp}.tmp", _pathFileData);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public CandidatoDTO FindById(string id)
        {
            var candidato = new Candidato();

            using (var reader = new StreamReader(_pathFileData))
            {
                string linha;

                while ((linha = reader.ReadLine()) is not null)
                {
                    if (linha.Split("|")[0].ToString().Contains(id))
                    {
                        candidato = SetCandidato(linha);
                    }
                }
            }

            return _mapper.Map<CandidatoDTO>(candidato);
        }

        public List<CandidatoDTO> FindByName(string nomeCandidato)
        {
            var listaCandidato = new List<CandidatoDTO>();

            using (var reader = new StreamReader(_pathFileData))
            {
                string linha;

                while ((linha = reader.ReadLine()) is not null)
                {
                    if (linha.Split("|")[1].ToString().ToLower().Contains(nomeCandidato.ToLower()))
                    {
                        var candidato = SetCandidato(linha);
                        var candidatoDto = _mapper.Map<CandidatoDTO>(candidato);
                        listaCandidato.Add(candidatoDto);
                    }
                }
            }

            return listaCandidato;
        }

        public List<CandidatoDTO> FindAll()
        {
            var listaCandidato = new List<CandidatoDTO>();

            using (var reader = new StreamReader(_pathFileData))
            {
                string linha;

                while ((linha = reader.ReadLine()) is not null)
                {
                    var candidato = SetCandidato(linha);
                    var candidatoDto = _mapper.Map<CandidatoDTO>(candidato);
                    listaCandidato.Add(candidatoDto); 
                }
            }

            return listaCandidato;
        }

        #region Metodos Private
        private static Candidato SetCandidato(string linha)
        {
            var telefone = linha.Split("|")[3].ToString();
            var telefoneFormatado = string.Empty;

            if (!string.IsNullOrEmpty(telefone))
            {
                telefoneFormatado = $"({telefone.Substring(0, 2)}) {telefone.Substring(2, 5)}-{telefone.Substring(7, 4)}";
            }

            return new Candidato
            {
                Id = Guid.Parse(linha.Split("|")[0].ToString()),
                Nome = linha.Split("|")[1].ToString(),
                Sexo = linha.Split("|")[2][0],
                Telefone = telefoneFormatado,
                Email = linha.Split("|")[4].ToString(),
            };
        }
        #endregion

    }
}
