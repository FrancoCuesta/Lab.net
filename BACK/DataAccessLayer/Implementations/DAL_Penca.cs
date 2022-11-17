﻿using DataAccessLayer.Interfaces;
using DataAccessLayer.Migrations;
using DataAccessLayer.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Penca = DataAccessLayer.Models.Penca;

namespace DataAccessLayer.Implementations
{
    public class DAL_Penca : IDAL_Penca
    {
        public List<Shared.Penca> GetPenca()
        {
            using (var db = new DataAccessLayer.Models.TuPencaContext())
            {
                return db.Penca.Select(x => x.ToEntity()).ToList();
            }
        }
        public Shared.Penca? Get(int id)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                Penca? penca = db.Penca.Where(x => x.Id == id).FirstOrDefault();
                if (penca != null)
                {
                    Shared.Penca? ret = penca.ToEntity();
                    ICollection<Shared.User_Penca>? user = db.User_Penca.Where(x => x.Id == id).Select(x => x.ToEntity()).ToList();
                    if (user.Count > 0)
                        ret.User_Penca = user;
                    return ret;
                }
                else
                {
                    return null;
                }
            }
        }
        
        public Shared.Penca AddPenca(Shared.Penca penca)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                Shared.Penca? existe = Get(penca.Id);
                if (existe != null)
                    throw new Exception("Ya existe una Penca con esa id");
                else
                {
                    var x = DataAccessLayer.Models.Penca.ToSave(penca);
                    db.Penca.Add(x);
                    db.SaveChanges();
                    return x.ToEntity();
                }

            }
        }

        public Shared.Penca SetPenca(Shared.Penca penca)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                Shared.Penca existe = Get(penca.Id);
                if (existe == null)
                    throw new Exception("No existe una Penca con ese id");
                else { 
                    var x = DataAccessLayer.Models.Penca.ToSave(penca);
                    db.Penca.Update(x);
                    db.SaveChanges();
                    return x.ToEntity();
                }
            }
        }

        public Shared.Penca AddCampeonato(int c, int p)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                Shared.Penca existe = Get(p);
                if (existe == null)
                    throw new Exception("No existe una Penca con ese id");
                else
                {
                    var y = db.Campeonatos.Where(x => x.id == c).FirstOrDefault();
                    if (y == null)
                        throw new Exception("No existe un Campeonato con ese id");
                    else {
                        var x = db.Penca.Where(x => x.Id == p).FirstOrDefault();
                        x.CampeonatoId = y.id;
                        db.Update(x);
                        db.SaveChanges();
                        return x.ToEntity();
                    }
                }
            }
        }
        public Shared.Penca DeleteCampeonato(int p)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                Shared.Penca existe = Get(p);
                if (existe == null)
                    throw new Exception("No existe una Penca con ese id");
                else
                {
                    Models.Penca penca = Models.Penca.ToSave(existe);
                    if (penca.CampeonatoId== null)
                        throw new Exception("No existe un Campeonato en esta Penca");
                    else
                    {
                        penca.CampeonatoId = null;
                        db.Penca.Update(penca);
                        db.SaveChanges();
                        return penca.ToEntity();
                    }
                }
            }
        }

        public Shared.User_Penca SetUsuarios(string u, int p){
            using (TuPencaContext db = new TuPencaContext()){
                Shared.Penca existe = Get(p);
                if (existe == null)
                    throw new Exception("No existe una Penca con ese id");
                else
                {
                    Models.Penca penca = Models.Penca.ToSave(existe);
                    Models.Users user = db.Users.Where(x => x.Id == u).FirstOrDefault();
                    if (user == null)
                        
                        throw new Exception("No existe un Usuario con ese id");
                    else
                    {
                        Models.User_Penca user_penca = db.User_Penca.Where(x => x.PencaId == p && x.UserId == u).FirstOrDefault();
                        if (user_penca == null)
                        {
                            user_penca = new Models.User_Penca();
                            user_penca.PencaId = p;
                            user_penca.UserId = u;
                            db.User_Penca.Add(user_penca);
                            db.SaveChanges();
                            return user_penca.ToEntity();
                        }
                        else
                            throw new Exception("El usuario ya esta en la penca");
                    }
                }
            }
        }

        public bool Deleteusuarios(string u, int p)
        {
            using (TuPencaContext db = new TuPencaContext())
            {
                Shared.Penca existe = Get(p);
                if (existe == null)
                    throw new Exception("No existe una Penca con ese id");
                else
                {
                    Models.Users user = db.Users.Where(x => x.Id == u).FirstOrDefault();
                    if (user == null)
                        throw new Exception("No existe un Usuario con ese id");
                    else
                    {
                        Models.User_Penca user_penca = db.User_Penca.Where(x => x.PencaId == p && x.UserId == u).FirstOrDefault();
                        if (user_penca == null)
                            throw new Exception("El usuario no esta en la penca");
                        else
                        {
                            db.User_Penca.Remove(user_penca);
                            db.SaveChanges();
                            return true;
                        }
                    }
                }
            }
        }

    }
}
