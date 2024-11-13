namespace Perforce.Handlers;

interface IHandler
{
    Response Handle(Request request);
}