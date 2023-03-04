using CleanArchitecture.Application.Constants;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.MinimalApi.Util;
using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.MinimalApi
{
    public static class UsersModule
    {
         public static void AddUserEndpoint(this IEndpointRouteBuilder app,IConfiguration configuration)
        {
            app.MapPost("/users/authenticate", [AllowAnonymous] async (Usuario usuario, IUnitOfWork unitOfWork) =>
            {
                try
                {
                    ITokenService tokenService = new TokenService(configuration);
                    if (usuario == null) Results.BadRequest();
                    usuario!.Password = Encrypt.EncodeToBase64(usuario.Password);
                    var credencial = await unitOfWork.userServices.ValidateUser(usuario);
                    if (credencial != null)
                    {
                        var Token = tokenService.BuildToken(usuario);
                        credencial.Token = Token;
                        return Results.Ok(credencial);
                    }
                    else
                    {
                        return Results.NotFound();
                    }
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }

            });

            app.MapGet("/users", [Authorize] async (IUnitOfWork unitOfWork) =>
            {
                try
                {
                    List<Usuario> result = await unitOfWork.userServices.GetAll();
                    if (result.Count == 0) return Results.NotFound();

                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
            app.MapGet("/users/{id}", [Authorize] async (int id, IUnitOfWork unitOfWork) =>
            {
                try
                {
                    Usuario result = await unitOfWork.userServices.GetById(id);
                    result.Password = Encrypt.DecodeToBase64(result.Password);
                    if (result == null) return Results.NotFound();

                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
            app.MapPost("/users/register", async (Usuario usuario, IUnitOfWork unitOfWork) =>
            {
                string resp = string.Empty;
                RespuestaTransaccionDto respuestaTransaccionDto = new();
                try
                {
                    usuario.Password = Encrypt.EncodeToBase64(usuario.Password);
                    unitOfWork.userServices.Insert(usuario);
                    int result = await unitOfWork.CommitAsync();
                    if (result == 0)
                    {
                        return Results.BadRequest();
                    }

                    respuestaTransaccionDto.Resultado = Mensajes.CODE_SUCCESS;
                    respuestaTransaccionDto.Descripcion = Mensajes.TRANSACTION_SUCCESS;
                    return Results.Ok(respuestaTransaccionDto);
                }
                catch (Exception ex)
                {
                    respuestaTransaccionDto.Resultado = Mensajes.CODE_ERROR;
                    respuestaTransaccionDto.Descripcion = Mensajes.ERROR_TRANSACTION + ex.Message;
                    return Results.BadRequest(respuestaTransaccionDto);
                }
            });

            app.MapPut("/users/{id}", [Authorize] async (int id, Usuario usuario, IUnitOfWork unitOfWork) =>
            {
                RespuestaTransaccionDto respuestaTransaccionDto = new();
                try
                {
                    usuario.Id = id;
                    usuario.Password = Encrypt.EncodeToBase64(usuario.Password);
                    unitOfWork.userServices.Update(usuario);
                    int result = await unitOfWork.CommitAsync();
                    if (result == 0)
                    {
                        return Results.BadRequest();
                    }

                    respuestaTransaccionDto.Resultado = Mensajes.CODE_SUCCESS;
                    respuestaTransaccionDto.Descripcion = Mensajes.TRANSACTION_SUCCESS;
                    return Results.Ok(respuestaTransaccionDto);
                }
                catch (Exception ex)
                {
                    respuestaTransaccionDto.Resultado = Mensajes.CODE_ERROR;
                    respuestaTransaccionDto.Descripcion = Mensajes.ERROR_TRANSACTION + ex.Message;
                    return Results.BadRequest(respuestaTransaccionDto);
                }
            });

            app.MapDelete("/users/{id}", [Authorize] async (int id, IUnitOfWork unitOfWork) =>
            {
                RespuestaTransaccionDto respuestaTransaccionDto = new();
                try
                {
                    unitOfWork.userServices.Delete(id);
                    int result = await unitOfWork.CommitAsync();
                    if (result == 0) return Results.BadRequest();
                    respuestaTransaccionDto.Resultado = Mensajes.CODE_SUCCESS;
                    respuestaTransaccionDto.Descripcion = Mensajes.TRANSACTION_SUCCESS;
                    return Results.Ok(respuestaTransaccionDto);
                }
                catch (Exception ex)
                {
                    respuestaTransaccionDto.Resultado = Mensajes.CODE_ERROR;
                    respuestaTransaccionDto.Descripcion = Mensajes.ERROR_TRANSACTION + ex.Message;
                    return Results.BadRequest(respuestaTransaccionDto);
                }
            });
        }
    }
}
