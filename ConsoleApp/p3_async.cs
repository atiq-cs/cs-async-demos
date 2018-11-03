// Copyright (c) FFTSys Inc. All rights reserved.
// Use of this source code is governed by a GPL-v3 license

namespace AsyncDemos {
  using System;
  using System.Threading.Tasks;

  /// <summary>
  /// Async with Task: right way to do it
  /// However, delay won't be noticeable
  /// 
  /// Part of artilce: https://atiqcs.wordpress.com/2018/08/18/csharp-async-programming/
  /// </summary>
  class p3CallAsyncWithoutAwait {
    static void Main(string[] args) {
      ThreadingTest demo = new ThreadingTest();
      Console.WriteLine("Before running my foo()");
      demo.Run();
      // synchronous sleep
      // System.Threading.Thread.Sleep(6000);
      Console.WriteLine("After running my foo()");
    }
  }

  class ThreadingTest {
    public async Task Run() {
      Console.WriteLine("my current thread");
      var asyncStr = await Task.Run(() => MyFoo());
      Console.WriteLine("my synchronous method..");
      Console.WriteLine("thread result: " + asyncStr);
    }

    public string MyFoo() {
      Console.WriteLine("my new thread.");
      Task.Delay(4000);   // this delay wouldn't have an effect
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
After running my foo()
new thread finished.
my synchronous method..
thread result: f00
*/
