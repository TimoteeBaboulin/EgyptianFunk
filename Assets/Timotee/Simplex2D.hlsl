void Simplex2D_float(float2 p, out float v)
{
    float2 i = floor(p + (p.x + p.y) * (sqrt(3.0) - 1.0) * 0.5);
    float2 f = p - i + (i.x + i.y) * (1.0 / 6.0) * (sqrt(3.0) - 1.0);
    float2 s = step(f.yx, f.xx);
    float2 u = f - s + (1.0 / 6.0) * (sqrt(3.0) - 1.0);
    float a = dot(u, float2(1.0, 1.0) - s * float2(1.0, -1.0));
    float2 o = (a < 0.0) ? float2(0.0, 0.0) : float2(0.0, 1.0);
    float2 b = u - s + (1.0 / 6.0) * (sqrt(3.0) - 1.0);
    float c = dot(b, float2(1.0, 1.0) - o * float2(1.0, -1.0));
    v = (a + max(0.0, c)) * 23.0;
    return;
}
