using System;
using System.Collections.Generic;
using DataConnection.Data;
using DataConnection.Models;
using DataTransferObject.Persona;
using System.Text;
using System.Linq;

namespace DataAccess
{
    public class PersonaDAO : IPersonaDAO
    {
        private readonly ApplicationDbContext _context;
        public PersonaDAO(ApplicationDbContext ctx)
        {
            _context = ctx;
        }
        #region Operations
        public List<Persona> listPersons()
        {
            return _context.persona.OrderByDescending(x => x.id_persona).ToList();
        }
        public Persona findPersonByIdentification(string identifiction)
        {
            if (_context.persona.Any(x => x.documento_identidad.Trim() == identifiction.Trim()))
            {
                var existente = _context.persona.FirstOrDefault(x => x.documento_identidad.Trim() == identifiction.Trim());
                return existente;
            }
            else
            {
                return null;
            }
        }
        public bool createPerson(PersonaDTO person)
        {
            Persona newPerson = new Persona()
            {
                apellidos = person.apellidos.ToUpper(),
                documento_identidad = person.documento_identidad,
                fecha_nacimiento = person.fecha_nacimiento,
                nombres = person.nombres.ToUpper()
            };
            _context.persona.Add(newPerson);
            _context.SaveChanges();

            //validate info contact
            if (person.informacionContactoDTO.Count > 0)
            {
                foreach (var contact in person.informacionContactoDTO)
                {
                    InformacionContacto newInfoContact = new InformacionContacto();
                    newInfoContact.email = contact.email;
                    newInfoContact.celular = contact.celular;
                    newInfoContact.telefono = contact.telefono;
                    newInfoContact.direccion_residencia = contact.direccion_residencia;
                    newInfoContact.id_persona = newPerson.id_persona;
                    _context.informacionContacto.Add(newInfoContact);
                    _context.SaveChanges();
                }
            }

            return newPerson.id_persona != 0 ? true : false;
        }
        public bool updatePerson(PersonaDTO person)
        {
            if (_context.persona.Any(x => x.id_persona == person.id_persona))
            {
                var existente = _context.persona.FirstOrDefault(x => x.id_persona == person.id_persona);

                //update
                existente.fecha_nacimiento = person.fecha_nacimiento;
                existente.nombres = person.nombres != "" ? person.nombres.ToUpper() : "";
                existente.apellidos = person.apellidos != "" ? person.apellidos.ToUpper() : "";
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

            Persona newPerson = new Persona()
            {
                apellidos = person.apellidos.ToUpper(),
                documento_identidad = person.documento_identidad,
                fecha_nacimiento = person.fecha_nacimiento,
                nombres = person.nombres.ToUpper()
            };
            _context.persona.Add(newPerson);
            _context.SaveChanges();
            return newPerson.id_persona != 0 ? true : false;
        }
        #endregion
    }
    public interface IPersonaDAO
    {
        List<Persona> listPersons();
        Persona findPersonByIdentification(string identifiction);
        bool createPerson(PersonaDTO person);
        bool updatePerson(PersonaDTO person);
    }
}
