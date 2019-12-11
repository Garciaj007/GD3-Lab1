using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable, PostProcess(typeof(DrunkImageShaderRenderer), PostProcessEvent.AfterStack, "CustomPostProcessing/Drunk")]
public sealed class DrunkImageShader : PostProcessEffectSettings
{
    public FloatParameter power = new FloatParameter() {value = 0};
    public Vector2Parameter direction = new Vector2Parameter() {value = Vector2.right};
}

public sealed class DrunkImageShaderRenderer : PostProcessEffectRenderer<DrunkImageShader>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/DrunkImageShader"));
        sheet.properties.SetFloat("_Power", settings.power);
        sheet.properties.SetVector("_Direction", settings.direction);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}
