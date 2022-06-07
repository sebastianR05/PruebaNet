using APIPersona.Models.Request;
using APIPersonas.Models.Response;
using BussinesLogic;
using DataTransferObject.Persona;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIPersona.Controllers
{
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaBL _PersonaBL;
        public PersonaController(IPersonaBL personaBL)
        {
            _PersonaBL = personaBL;
        }

        /// <summary>Consultar Personas</summary>
        /// <returns>Listado de las personas</returns>
        /// <response code="200">Solicitud procesada</response>
        /// <response code="400">Problemas con la solicitud</response>
        /// <response code="401">Falta de permisos</response>
        /// <remarks>
        /// `Descripción:`
        /// ```
        /// Servicio disponible para consultar la información de las personas registradas en el sistema.       
        /// </remarks>
        [ProducesResponseType(typeof(IEnumerable<PersonaDTO>), 200)]
        [HttpGet]
        [Route("api/persona/listaPersonas")]
        public ResponseGeneral listaPersonas()
        {
            ResponseGeneral response = new ResponseGeneral();
            try
            {
                var result = _PersonaBL.listPersons();
                response.exitoso = result.Count > 0 ? true : false;
                response.mensaje = response.exitoso ? "Se consultó la data correctamente" : "No se encontró información";
                response.data = result;
            }
            catch (Exception ex)
            {
                response.mensaje = "Ha ocurrido un error consultando la lista de personas";
                response.data = ex.Message.ToString();
            }
            return response;
        }

        /// <summary>Crear Persona</summary>
        /// <returns>Objeto de la persona creada</returns>
        /// <response code="200">Solicitud procesada</response>
        /// <response code="400">Problemas con la solicitud</response>
        /// <response code="401">Falta de permisos</response>
        /// <remarks>
        /// `Descripción:`
        /// ```
        /// Servicio disponible para crear una persona en el sistema.       
        /// </remarks>
        [ProducesResponseType(typeof(IEnumerable<PersonaDTO>), 200)]
        [HttpPost]
        [Route("api/persona/crearPersona")]
        public ResponseGeneral crearPersona(PersonRequest request)
        {
            ResponseGeneral response = new ResponseGeneral();
            try
            {
                PersonaDTO personaDTO = new PersonaDTO();
                personaDTO.documento_identidad = request.documento_identidad;
                personaDTO.apellidos = request.apellidos;
                personaDTO.nombres = request.nombres;
                personaDTO.fecha_nacimiento = request.fecha_nacimiento;
                personaDTO.informacionContactoDTO = new List<InformacionContactoDTO>();
                if (request.info_contacto.Count > 0)
                {
                    foreach (var item in request.info_contacto)
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

                var result = _PersonaBL.createPerson(personaDTO);
                response.exitoso = result;
                response.mensaje = response.exitoso ? "Se creó la persona " + request.nombres + " " + request.apellidos + " correctamente" : "No se pudo crear la persona";
                response.data = result;
            }
            catch (Exception ex)
            {
                response.mensaje = "Ha ocurrido un error creando la persona";
                response.data = ex.Message.ToString();
            }
            return response;
        }

        /// <summary>Actualizar Persona</summary>
        /// <returns>Valor booleano de la actualización</returns>
        /// <response code="200">Solicitud procesada</response>
        /// <response code="400">Problemas con la solicitud</response>
        /// <response code="401">Falta de permisos</response>
        /// <remarks>
        /// `Descripción:`
        /// ```
        /// Servicio disponible para actualizar una persona en el sistema.       
        /// </remarks>
        [ProducesResponseType(typeof(IEnumerable<PersonaDTO>), 200)]
        [HttpPut]
        [Route("api/persona/actualziarPersona")]
        public ResponseGeneral actualziarPersona(UpdatePersonRequest request)
        {
            ResponseGeneral response = new ResponseGeneral();
            try
            {
                PersonaDTO personaDTO = new PersonaDTO();
                personaDTO.documento_identidad = request.documento_identidad;
                personaDTO.id_persona = request.id_persona;
                personaDTO.apellidos = request.apellidos;
                personaDTO.nombres = request.nombres;
                personaDTO.fecha_nacimiento = request.fecha_nacimiento;
                personaDTO.informacionContactoDTO = new List<InformacionContactoDTO>();
                if (request.info_contacto.Count > 0)
                {
                    foreach (var item in request.info_contacto)
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

                var result = _PersonaBL.updatePerson(personaDTO);
                response.exitoso = result;
                response.mensaje = response.exitoso ? "Se actualizó la persona " + request.nombres + " " + request.apellidos + " correctamente" : "No se pudo actualizar la persona";
                response.data = result;
            }
            catch (Exception ex)
            {
                response.mensaje = "Ha ocurrido un error actualizando la persona";
                response.data = ex.Message.ToString();
            }
            return response;
        }
    }
}
