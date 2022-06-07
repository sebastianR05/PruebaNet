using DataAccess;
using DataTransferObject.Persona;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic
{
    public class PersonaBL : IPersonaBL
    {
        private readonly IPersonaDAO _PersonaDAO;
        public PersonaBL(IPersonaDAO personaDao)
        {
            _PersonaDAO = personaDao;
        }
        public List<PersonaDTO> listPersons()
        {
            List<PersonaDTO> listaPerson = new List<PersonaDTO>();
            var lista = _PersonaDAO.listPersons();
            if (lista.Count > 0)
            {
                foreach (var item in lista)
                {
                    PersonaDTO person = new PersonaDTO();
                    person.apellidos = item.apellidos;
                    person.documento_identidad = item.apellidos;
                    person.fecha_nacimiento = item.fecha_nacimiento;
                    person.id_persona = item.id_persona;
                    person.nombres = item.nombres;
                    person.informacionContactoDTO = new List<InformacionContactoDTO>();
                    if (item.informacion_contacto.Count > 0)
                    {
                        foreach (var contact in item.informacion_contacto)
                        {
                            InformacionContactoDTO contactoDto = new InformacionContactoDTO();
                            contactoDto.email = contact.email;
                            contactoDto.celular = contact.celular;
                            contactoDto.id_persona = contact.id_persona;
                            contactoDto.id_info_contacto = contact.id_info_contacto;
                            contactoDto.direccion_residencia = contact.direccion_residencia;
                            person.informacionContactoDTO.Add(contactoDto);
                        }
                    }
                    listaPerson.Add(person);
                }
            }
            return listaPerson;
        }
        public PersonaDTO findPersonByIdentification(string identifiction)
        {
            var registro = _PersonaDAO.findPersonByIdentification(identifiction);
            if (registro != null)
            {
                PersonaDTO personaDTO = new PersonaDTO();
                personaDTO.id_persona = registro.id_persona;
                personaDTO.documento_identidad = registro.documento_identidad;
                personaDTO.apellidos = registro.apellidos;
                personaDTO.nombres = registro.nombres;
                personaDTO.fecha_nacimiento = registro.fecha_nacimiento;
                personaDTO.informacionContactoDTO = new List<InformacionContactoDTO>();
                if (registro.informacion_contacto.Count > 0)
                {
                    foreach (var item in registro.informacion_contacto)
                    {
                        InformacionContactoDTO contactoDTO = new InformacionContactoDTO();
                        contactoDTO.email = item.email;
                        contactoDTO.celular = item.celular;
                        contactoDTO.telefono = item.telefono;
                        contactoDTO.id_persona = item.id_persona;
                        contactoDTO.direccion_residencia = item.direccion_residencia;
                        contactoDTO.id_info_contacto = item.id_info_contacto;
                        personaDTO.informacionContactoDTO.Add(contactoDTO);
                    }
                }
                return personaDTO;
            }
            else
            {
                return null;
            }
        }
        public bool createPerson(PersonaDTO person)
        {
            return _PersonaDAO.createPerson(person);
        }
        public bool updatePerson(PersonaDTO person)
        {
            return _PersonaDAO.updatePerson(person);
        }
    }
    public interface IPersonaBL
    {
        List<PersonaDTO> listPersons();
        PersonaDTO findPersonByIdentification(string identifiction);
        bool createPerson(PersonaDTO person);
        bool updatePerson(PersonaDTO person);
    }
}
