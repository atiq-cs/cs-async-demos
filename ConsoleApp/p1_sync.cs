// Copyright (c) FFTSys Inc. All rights reserved.
// Use of this source code is governed by a GPL-v3 license

namespace AsyncDemos {
  using System;
  using System.Threading.Tasks;

  /// <summary> Synchronous Thread: demonstrating synchronous flow of the methods
  /// Exampe run is at bottom
  /// 
  /// Part of artilce: https://atiqcs.wordpress.com/2018/08/18/csharp-async-programming/
  /// </summary>
  class p1Sync {
    static void Main(string[] args) {
      ThreadingTest demo = new ThreadingTest();
      Console.WriteLine("Before running my foo()");
      demo.Run();
      Console.WriteLine("After running my foo()");
    }
  }

  class ThreadingTest {
    public void Run() {
      Console.WriteLine("my current thread");
      var syncThreadStr = Task.Run(() => MyFoo()).Result;
      Console.WriteLine("my synchronous method..");
      Console.WriteLine("thread result: " + syncThreadStr);
    }

    public string MyFoo() {
      Console.WriteLine("my new thread.");
      Task.Delay(1000);
      Console.WriteLine("new thread finished.");
      return "f00";
    }
  }
}

/*
Example output,
Before running my foo()
my current thread
my new thread.
new thread finished.
my synchronous method..
thread result: f00
After running my foo()
*/
