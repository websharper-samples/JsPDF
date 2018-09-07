namespace WebSharper.JsPDF.Sample

open WebSharper
open WebSharper.JavaScript
open WebSharper.JsPDF
open WebSharper.JQuery
open WebSharper.UI
open WebSharper.UI.Client
open WebSharper.UI.Html
open WebSharper.UI.Templating

[<JavaScript>]
module Client =
    type IndexTemplate = Template<"wwwroot/index.html", ClientLoad.FromDocument>

    [<SPAEntryPoint>]
    let Main () =

        let doc = new JsPDF()

        doc.Text("Hello world!", 10., 10., obj) |> ignore
        doc.AddPage()
        doc.Text("Hello world on Page 2!", 10., 10., obj) |> ignore
        let pdf = doc.Output("bloburl", obj).ToString()

        let pdfRender =
            Tags.``object`` [
                attr.width "100%"
                attr.height "100%"
                attr.data pdf
                attr.``type`` "application/pdf"
            ] []

        IndexTemplate.Main()
            .PDF(pdfRender)
            .Doc()
        |> Doc.RunById "main"
