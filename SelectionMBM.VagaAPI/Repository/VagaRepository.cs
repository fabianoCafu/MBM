using AutoMapper;
using SelectionMBM.VagaAPI.DTO;
using SelectionMBM.VagaAPI.Model;
using SelectionMBM.VagaAPI.Repository.Interface;

namespace SelectionMBM.VagaAPI.Repository
{
    public class VagaRepository : IVagaRepository
    {
        private readonly IMapper _mapper;
        public readonly string _pathFileDataVaga;
        public readonly string _pathFileDataCandidatos;

        public VagaRepository(
            IMapper? mapper,
            IConfiguration config)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _pathFileDataVaga = config["FileSettings:VagaRepository"];
            _pathFileDataCandidatos = config["FileSettings:CandidatosRepository"];
        }

        public bool Create(VagaDTO vagaDTO)
        {
            try
            {
                using var write = new StreamWriter(_pathFileDataVaga, true);
                var registro = $"{Guid.NewGuid()}|{vagaDTO.TituloVaga}|{vagaDTO.LocalVaga}|{vagaDTO.Modalidade}|{vagaDTO.Organizacao}|{vagaDTO.Descricao}|";

                write.WriteLine(registro);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(VagaDTO vagaDTO)
        {
            try
            {
                var pathTemp = Path.GetFileNameWithoutExtension(_pathFileDataVaga);
                var registro = $"{vagaDTO.Id}|{vagaDTO.TituloVaga}|{vagaDTO.LocalVaga}|{vagaDTO.Modalidade}|{vagaDTO.Organizacao}|{vagaDTO.Descricao}|";

                using (var reader = new StreamReader(_pathFileDataVaga))
                {
                    using var write = new StreamWriter($"{pathTemp}.tmp");
                    string linha;

                    while ((linha = reader.ReadLine()) is not null)
                    {
                        if (linha.Split("|")[0].ToString() == vagaDTO.Id.ToString())
                        {
                            write.WriteLine(registro);
                        }
                        else
                        {
                            write.WriteLine(linha);
                        }
                    }
                }

                File.Delete(_pathFileDataVaga);
                File.Move($"{pathTemp}.tmp", _pathFileDataVaga);

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
                var pathTemp = Path.GetFileNameWithoutExtension(_pathFileDataVaga);

                using (var reader = new StreamReader(_pathFileDataVaga))
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

                File.Delete(_pathFileDataVaga);
                File.Move($"{pathTemp}.tmp", _pathFileDataVaga);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public VagaDTO FindById(string id)
        {
            var vaga = new Vaga();

            using (var reader = new StreamReader(_pathFileDataVaga))
            {
                string linha;

                while ((linha = reader.ReadLine()) is not null)
                {
                    if (linha.Split("|")[0].ToString().Contains(id))
                    {
                        vaga = SetVaga(linha);
                    }
                }
            }

            return _mapper.Map<VagaDTO>(vaga);
        }

        public List<VagaDTO> FindByTitle(string titleVaga)
        {
            var listaVagas = new List<VagaDTO>();

            using (var reader = new StreamReader(_pathFileDataVaga))
            {
                string linha;

                while ((linha = reader.ReadLine()) is not null)
                {
                    if (linha.Split("|")[1].ToString().ToLower().Contains(titleVaga.ToLower()))
                    {
                        var candidato = SetVaga(linha);
                        var candidatoDto = _mapper.Map<VagaDTO>(candidato);
                        listaVagas.Add(candidatoDto);
                    }
                }
            }

            return listaVagas;
        }

        public List<VagaDTO> FindAll()
        {
            var listaVagas = new List<VagaDTO>();

            using (var reader = new StreamReader(_pathFileDataVaga))
            {
                string linha;

                while ((linha = reader.ReadLine()) is not null)
                {
                    var vaga = SetVaga(linha);
                    var candidatoDto = _mapper.Map<VagaDTO>(vaga);
                    listaVagas.Add(candidatoDto);
                }
            }

            return listaVagas;
        }

        public List<CandidatosDTO> FindByOpportunity(string id)
        {
            var listaCandidatos = new List<CandidatosDTO>();

            using (var reader = new StreamReader(_pathFileDataCandidatos))
            {
                string linha;

                while ((linha = reader.ReadLine()) is not null)
                {
                    if (linha.Split("|")[0].ToString().Contains(id))
                    {
                        var candidatos = SetCanditos(linha);
                        var candidatosDto = _mapper.Map<CandidatosDTO>(candidatos);
                        listaCandidatos.Add(candidatosDto);
                    }
                }
            }

            return listaCandidatos;
        }

        #region Metodos Private
        private static Candidato SetCanditos(string linha)
        {
            return new Candidato
            {
                IdVaga = Guid.Parse(linha.Split("|")[0].ToString()),
                TituloVaga = linha.Split("|")[1].ToString(),
                IdCandidato = Guid.Parse(linha.Split("|")[2].ToString()),
                Nome = linha.Split("|")[3].ToString(),
                StatusDoProcesso = linha.Split("|")[4][0]
            };
        }

        private static Vaga SetVaga(string linha)
        {
            return new Vaga
            {
                Id = Guid.Parse(linha.Split("|")[0].ToString()),
                TituloVaga = linha.Split("|")[1].ToString(),
                LocalVaga = linha.Split("|")[2].ToString(),
                Modalidade = linha.Split("|")[3].ToString(),
                Organizacao = linha.Split("|")[4].ToString(),
                Descricao = linha.Split("|")[5].ToString()
            };
        }
        #endregion
    }
}
