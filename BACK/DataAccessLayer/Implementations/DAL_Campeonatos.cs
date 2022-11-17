﻿using System;
using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Migrations;
using System.Security.Cryptography.X509Certificates;

namespace DataAccessLayer.Implementations
{
public class DAL_Campeonatos : IDAL_Campeonatos
 {
        public List<Shared.Campeonato> GetCampeonatos()
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                return db.Campeonatos.Select(x => x.ToEntity()).ToList();
            }
        }

        public Shared.Campeonato Get(int id)
        {
            using(TuPencaContext db = new TuPencaContext())
            {
                Shared.Campeonato p = db.Campeonatos.Where(x => x.id == id).FirstOrDefault()?.ToEntity();
                ICollection<Shared.Partido>? par= db.Partidos.Where(x => x.Campeonatoid == id).Select(x => x.ToEntity()).ToList();
                if(par.Count > 0 ) {
                    p.partidos = par;
                }
                return p;
            }
        }

        public Shared.Campeonato AddCampeonato(Shared.Campeonato c)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                Shared.Campeonato existe = Get(c.id);
                if (existe != null)
                {
                    throw new Exception("Ya existe un Campeonato con esa id");
                }
                else
                {
                    Models.Campeonato nuevo = Models.Campeonato.ToSave(c);
                    db.Campeonatos.Add(nuevo);
                    db.SaveChanges();

                    return Get(c.id);
                }

            }

        }

        public Shared.Campeonato SetCampeonato(Shared.Campeonato c)
        {

            using (TuPencaContext db =new TuPencaContext())
            {

                Shared.Campeonato existe = Get(c.id);
                if (existe == null)
                {
                    throw new Exception("No existe un Campeonato con ese id");
                }
                else
                {
                    Models.Campeonato campeonato = Models.Campeonato.ToSave(c);
                    db.Campeonatos.Update(campeonato);
                    db.SaveChanges();

                    return Get(c.id);

                }
            }
           
        }
        public Shared.Campeonato SetPartidos(int idC, int idP)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                Shared.Campeonato existe = Get(idC);
                if (existe == null)
                    throw new Exception("No existe un Campeonato con ese id");
                else
                {
                    Models.Campeonato campeonato = Models.Campeonato.ToSave(existe);
                    Models.Partido partido = db.Partidos.Where(x => x.id == idP).FirstOrDefault();
                    if (partido == null)
                        throw new Exception("No existe un Partido con ese id");
                    else
                    {
                        if (partido.Campeonatoid != null)
                            throw new Exception("Este Partido ya pertenece a un campeonato");
                        else
                        {
                            if (campeonato.partidos == null)
                            {
                                List<Models.Partido> partidos = new List<Models.Partido>();
                                partidos.Add(partido);
                                campeonato.partidos = partidos;
                                db.Campeonatos.Update(campeonato);
                                db.SaveChanges();
                                return Get(idC);
                            }
                            else
                            {
                                campeonato.partidos.Add(partido);
                                db.Campeonatos.Update(campeonato);
                                db.SaveChanges();
                                return Get(idC);
                            }
                        }
                    }
                }
            }
        }
        public Shared.Campeonato DeletePartidos(int idC, int idP)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                Shared.Campeonato existe = Get(idC);
                if (existe == null)
                    throw new Exception("No existe un Campeonato con ese id");
                else
                {
                    Models.Partido partido = db.Partidos.Where(x => x.id == idP).FirstOrDefault();
                    if (partido == null)
                        throw new Exception("No existe un Partido con ese id");
                    else
                    {
                        partido.Campeonatoid = null;
                        db.Partidos.Update(partido);
                        db.SaveChanges();
                        return Get(idC);
                    }
                }
            }
        }
        public Shared.Campeonato DeleteCampeonato(int id)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                Shared.Campeonato existe = Get(id);
                if (existe == null)
                    throw new Exception("No existe un Campeonato con ese id");
                else
                {
                    Models.Campeonato campeonato = Models.Campeonato.ToSave(existe);
                    db.Campeonatos.Remove(campeonato);
                    db.SaveChanges();
                    return existe;
                }
            }
        }
    }        
    
}
