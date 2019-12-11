using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable, PostProcess(typeof(HighImageShaderRenderer), PostProcessEvent.AfterStack, "CustomPostProcessing/High")]
public sealed class HighImageShader : PostProcessEffectSettings
{
    public FloatParameter power = new FloatParameter() { value = 0 };
    public FloatParameter intensity = new FloatParameter() { value = 0.5f };
    public FloatParameter blend = new FloatParameter() { value = 0 };
    public FloatParameter brightness = new FloatParameter() { value = 1.0f };
}

public sealed class HighImageShaderRenderer : PostProcessEffectRenderer<HighImageShader>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/HighImageShader"));
        sheet.properties.SetFloat("_Power", settings.power);
        sheet.properties.SetFloat("_Intensity", settings.intensity);
        sheet.properties.SetFloat("_Blend", settings.blend);
        sheet.properties.SetFloat("_Brightness", settings.brightness);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}


