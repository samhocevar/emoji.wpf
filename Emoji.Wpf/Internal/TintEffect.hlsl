//
//  Emoji.Wpf — Emoji support for WPF
//
//  Copyright © 2017–2022 Sam Hocevar <sam@hocevar.net>
//
//  This library is free software. It comes without any warranty, to
//  the extent permitted by applicable law. You can redistribute it
//  and/or modify it under the terms of the Do What the Fuck You Want
//  to Public License, Version 2, as published by the WTFPL Task Force.
//  See http://www.wtfpl.net/ for more details.
//

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
