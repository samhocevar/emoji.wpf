sampler2D input : register(s0);
float4 tint : register(c0);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(input, uv.xy);
    color.rgb /= color.a;
    color.rgb += (1.0.xxx - color.rgb) * tint.rgb;
    color.rgb *= color.a;
    return color;
}
