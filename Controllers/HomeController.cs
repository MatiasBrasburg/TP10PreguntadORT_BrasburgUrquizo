using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP03.Models;

namespace TP03.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {



        string? juegoJson = HttpContext.Session.GetString("Juego");
        Juego juegoIniciado;
        if (string.IsNullOrEmpty(juegoJson))
        {
            juegoIniciado = new Juego();
            HttpContext.Session.SetString("Juego", Objeto.ObjectToString(juegoIniciado));
        }
        else
        {
            juegoIniciado = Objeto.StringToObject<Juego>(juegoJson!);
        }

        return View();

    }
    public IActionResult ConfigurarJuego()
    {
        
        string? juegoJson = HttpContext.Session.GetString("Juego");
        Juego JuegoIniciado = Objeto.StringToObject<Juego>(juegoJson!);

        ViewBag.Categoria = BD.TraerCategorias();

          HttpContext.Session.SetString("Juego", Objeto.ObjectToString(JuegoIniciado));

        return View("ConfigurarJuego");
    }

    public IActionResult Comenzar(string username, int categoria)
    {
        string? juegoJson = HttpContext.Session.GetString("Juego");
        Juego JuegoIniciado = Objeto.StringToObject<Juego>(juegoJson!);

        
        JuegoIniciado.InicializarJuego();

         JuegoIniciado.CargarPartida(username, categoria);

        ViewBag.Username = username;
        ViewBag.CategoriaElegida = categoria;
        ViewBag.PuntajeActual = JuegoIniciado.PuntajeActual;
ViewBag.ListRespuestas = JuegoIniciado.ListaRespuestas; 
ViewBag.ListaPreguntas = JuegoIniciado.ListaPreguntas;
        
       

        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(JuegoIniciado));

        return RedirectToAction("Jugar");
    }

    public IActionResult Jugar()
    {
        string? juegoJson = HttpContext.Session.GetString("Juego");
        Juego JuegoIniciado = Objeto.StringToObject<Juego>(juegoJson!);
        Pregunta Proxima = JuegoIniciado.ObtenerProximaPregunta();


        if (Proxima == null)
        {
            HttpContext.Session.SetString("Juego", Objeto.ObjectToString(JuegoIniciado));
            return View("Fin");
        }
        else
        {
            ViewBag.Enunciado = Proxima.Enunciado;
            List<Respuesta> ListaRespuestas = JuegoIniciado.ObtenerProximasRespuestas(Proxima.Id);
            for (int i = 0; i < ListaRespuestas.Count; i++)
            {
                ViewBag.RespuestaOpcion = ListaRespuestas[i].Opcion;
                ViewBag.RespuestaContenido = ListaRespuestas[i].Contenido;
                ViewBag.RespuestaCorrecta = ListaRespuestas[i].Correcta;
            }
        }


        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(JuegoIniciado));


        return View("Juego");
    }



    [HttpPost]
    public IActionResult VerificarRespuesta(int idPregunta, int idRespuesta)
    {
        string? juegoJson = HttpContext.Session.GetString("Juego");
        Juego JuegoIniciado = Objeto.StringToObject<Juego>(juegoJson!);

        ViewBag.EstaCorrecta = JuegoIniciado.VerificarRespuesta(idRespuesta);
        List<Respuesta> Respuestas = JuegoIniciado.ObtenerProximasRespuestas(idPregunta);

        if (ViewBag.EstaCorrecta)
        {
            ViewBag.RespuestaCorrecta = Respuestas[idRespuesta];
        }
        else
        {
            for (int i = 0; i >= Respuestas.Count; i++)
            {
                if (Respuestas[i].Correcta)
                {
                    ViewBag.RespuestaCorrecta = Respuestas[i];
                }

            }
        }
   

        HttpContext.Session.SetString("Juego", Objeto.ObjectToString(JuegoIniciado));

        return View("Respuesta");
    }
}
