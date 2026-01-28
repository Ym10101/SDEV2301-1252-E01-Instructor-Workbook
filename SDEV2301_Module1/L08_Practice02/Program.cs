using L08_Practice02;

Shape[] shapes =
{
    new Circle(),
    new Rectangle(),   
    new Shape()
};
foreach (Shape currentShape in shapes)
{
    currentShape.Draw();
}
