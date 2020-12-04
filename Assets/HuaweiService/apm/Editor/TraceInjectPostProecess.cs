using UnityEditor;
using UnityEditor.Compilation;

namespace HuaweiService{
    [InitializeOnLoad]
    public class TraceInjectPostProecess{
        static TraceInjectPostProecess(){
            CompilationPipeline.assemblyCompilationFinished     += onFinished;
        }

        private static void onFinished(string arg1, CompilerMessage[] arg2){
            TraceInjector.Inject(arg1);
        }
    }
}

