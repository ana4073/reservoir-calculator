using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace ReservoirCalculator.Services
{
    /// <summary>
    /// Сервис для 3D визуализации резервуаров
    /// </summary>
    public class VisualizationService
    {
        public static Model3D CreateRVSModel(double diameter, double height, double roofHeight, string roofType)
        {
            var group = new Model3DGroup();
            double radius = diameter / 2.0;

            var cylinderMesh = CreateCylinderMesh(radius, height, 32);
            var cylinderGeometry = new GeometryModel3D(cylinderMesh, CreateMaterial(System.Windows.Media.Colors.LightBlue));
            group.Children.Add(cylinderGeometry);

            var bottomMesh = CreateDiskMesh(radius, 32);
            var bottomGeometry = new GeometryModel3D(bottomMesh, CreateMaterial(System.Windows.Media.Colors.LightGray));
            bottomGeometry.Transform = new TranslateTransform3D(0, -height / 2, 0);
            group.Children.Add(bottomGeometry);

            switch (roofType)
            {
                case "Коническая":
                    var coneMesh = CreateConeMesh(radius, roofHeight, 32);
                    var coneGeometry = new GeometryModel3D(coneMesh, CreateMaterial(System.Windows.Media.Colors.DarkGray));
                    coneGeometry.Transform = new TranslateTransform3D(0, height / 2, 0);
                    group.Children.Add(coneGeometry);
                    break;

                case "Плоская":
                    var flatMesh = CreateDiskMesh(radius, 32);
                    var flatGeometry = new GeometryModel3D(flatMesh, CreateMaterial(System.Windows.Media.Colors.DarkGray));
                    flatGeometry.Transform = new TranslateTransform3D(0, height / 2, 0);
                    group.Children.Add(flatGeometry);
                    break;

                case "Полусферичная":
                    var hemisphereMesh = CreateHemisphereMesh(radius, 32, 16);
                    var hemisphereGeometry = new GeometryModel3D(hemisphereMesh, CreateMaterial(System.Windows.Media.Colors.DarkGray));
                    hemisphereGeometry.Transform = new TranslateTransform3D(0, height / 2, 0);
                    group.Children.Add(hemisphereGeometry);
                    break;
            }

            return group;
        }

        public static Model3D CreateRGSModel(double diameter, double length, string bottomType)
        {
            var group = new Model3DGroup();
            double radius = diameter / 2.0;

            var cylinderMesh = CreateHorizontalCylinderMesh(radius, length, 32);
            var cylinderGeometry = new GeometryModel3D(cylinderMesh, CreateMaterial(System.Windows.Media.Colors.LightBlue));
            group.Children.Add(cylinderGeometry);

            var leftBottomMesh = CreateCircleMesh(radius, 32);
            var leftBottomGeometry = new GeometryModel3D(leftBottomMesh, CreateMaterial(System.Windows.Media.Colors.LightGray));
            leftBottomGeometry.Transform = new TranslateTransform3D(-length / 2, 0, 0);
            group.Children.Add(leftBottomGeometry);

            var rightBottomMesh = CreateCircleMesh(radius, 32);
            var rightBottomGeometry = new GeometryModel3D(rightBottomMesh, CreateMaterial(System.Windows.Media.Colors.LightGray));
            rightBottomGeometry.Transform = new TranslateTransform3D(length / 2, 0, 0);
            group.Children.Add(rightBottomGeometry);

            return group;
        }

        private static Material CreateMaterial(System.Windows.Media.Color color)
        {
            var brush = new System.Windows.Media.SolidColorBrush(color);
            return new DiffuseMaterial(brush);
        }

        private static MeshGeometry3D CreateCylinderMesh(double radius, double height, int segments)
        {
            var mesh = new MeshGeometry3D();
            double angleStep = 2 * System.Math.PI / segments;

            for (int i = 0; i <= segments; i++)
            {
                double angle = i * angleStep;
                double x = radius * System.Math.Cos(angle);
                double z = radius * System.Math.Sin(angle);
                mesh.Positions.Add(new Point3D(x, height / 2, z));
            }

            for (int i = 0; i <= segments; i++)
            {
                double angle = i * angleStep;
                double x = radius * System.Math.Cos(angle);
                double z = radius * System.Math.Sin(angle);
                mesh.Positions.Add(new Point3D(x, -height / 2, z));
            }

            for (int i = 0; i < segments; i++)
            {
                int i1 = i;
                int i2 = i + 1;
                int i3 = i + segments + 1;
                int i4 = i + segments + 2;

                mesh.TriangleIndices.Add(i1);
                mesh.TriangleIndices.Add(i3);
                mesh.TriangleIndices.Add(i2);

                mesh.TriangleIndices.Add(i2);
                mesh.TriangleIndices.Add(i3);
                mesh.TriangleIndices.Add(i4);
            }

            return mesh;
        }

        private static MeshGeometry3D CreateHorizontalCylinderMesh(double radius, double length, int segments)
        {
            var mesh = new MeshGeometry3D();
            double angleStep = 2 * System.Math.PI / segments;

            for (int i = 0; i <= segments; i++)
            {
                double angle = i * angleStep;
                double y = radius * System.Math.Cos(angle);
                double z = radius * System.Math.Sin(angle);
                mesh.Positions.Add(new Point3D(-length / 2, y, z));
            }

            for (int i = 0; i <= segments; i++)
            {
                double angle = i * angleStep;
                double y = radius * System.Math.Cos(angle);
                double z = radius * System.Math.Sin(angle);
                mesh.Positions.Add(new Point3D(length / 2, y, z));
            }

            for (int i = 0; i < segments; i++)
            {
                int i1 = i;
                int i2 = i + 1;
                int i3 = i + segments + 1;
                int i4 = i + segments + 2;

                mesh.TriangleIndices.Add(i1);
                mesh.TriangleIndices.Add(i2);
                mesh.TriangleIndices.Add(i3);

                mesh.TriangleIndices.Add(i2);
                mesh.TriangleIndices.Add(i4);
                mesh.TriangleIndices.Add(i3);
            }

            return mesh;
        }

        private static MeshGeometry3D CreateDiskMesh(double radius, int segments)
        {
            var mesh = new MeshGeometry3D();
            mesh.Positions.Add(new Point3D(0, 0, 0));

            double angleStep = 2 * System.Math.PI / segments;
            for (int i = 0; i <= segments; i++)
            {
                double angle = i * angleStep;
                double x = radius * System.Math.Cos(angle);
                double z = radius * System.Math.Sin(angle);
                mesh.Positions.Add(new Point3D(x, 0, z));
            }

            for (int i = 1; i <= segments; i++)
            {
                mesh.TriangleIndices.Add(0);
                mesh.TriangleIndices.Add(i);
                mesh.TriangleIndices.Add(i + 1);
            }

            return mesh;
        }

        private static MeshGeometry3D CreateCircleMesh(double radius, int segments)
        {
            return CreateDiskMesh(radius, segments);
        }

        private static MeshGeometry3D CreateConeMesh(double radius, double height, int segments)
        {
            var mesh = new MeshGeometry3D();
            mesh.Positions.Add(new Point3D(0, height, 0));

            double angleStep = 2 * System.Math.PI / segments;
            for (int i = 0; i <= segments; i++)
            {
                double angle = i * angleStep;
                double x = radius * System.Math.Cos(angle);
                double z = radius * System.Math.Sin(angle);
                mesh.Positions.Add(new Point3D(x, 0, z));
            }

            for (int i = 1; i <= segments; i++)
            {
                mesh.TriangleIndices.Add(0);
                mesh.TriangleIndices.Add(i + 1);
                mesh.TriangleIndices.Add(i);
            }

            for (int i = 1; i <= segments; i++)
            {
                mesh.TriangleIndices.Add(i);
                mesh.TriangleIndices.Add(i + 1);
                mesh.TriangleIndices.Add(1);
            }

            return mesh;
        }

        private static MeshGeometry3D CreateHemisphereMesh(double radius, int segments, int rings)
        {
            var mesh = new MeshGeometry3D();
            mesh.Positions.Add(new Point3D(0, radius, 0));

            for (int ring = 1; ring <= rings; ring++)
            {
                double phi = System.Math.PI * ring / (2 * rings);
                double y = radius * System.Math.Cos(phi);
                double r = radius * System.Math.Sin(phi);

                double angleStep = 2 * System.Math.PI / segments;
                for (int seg = 0; seg < segments; seg++)
                {
                    double angle = seg * angleStep;
                    double x = r * System.Math.Cos(angle);
                    double z = r * System.Math.Sin(angle);
                    mesh.Positions.Add(new Point3D(x, y, z));
                }
            }

            for (int seg = 0; seg < segments; seg++)
            {
                int next = (seg + 1) % segments;
                mesh.TriangleIndices.Add(0);
                mesh.TriangleIndices.Add(seg + 2);
                mesh.TriangleIndices.Add(next + 2);
            }

            for (int ring = 0; ring < rings - 1; ring++)
            {
                int currentRingStart = 1 + ring * segments;
                int nextRingStart = 1 + (ring + 1) * segments;

                for (int seg = 0; seg < segments; seg++)
                {
                    int next = (seg + 1) % segments;

                    mesh.TriangleIndices.Add(currentRingStart + seg);
                    mesh.TriangleIndices.Add(nextRingStart + seg);
                    mesh.TriangleIndices.Add(currentRingStart + next);

                    mesh.TriangleIndices.Add(currentRingStart + next);
                    mesh.TriangleIndices.Add(nextRingStart + seg);
                    mesh.TriangleIndices.Add(nextRingStart + next);
                }
            }

            return mesh;
        }
    }
}
