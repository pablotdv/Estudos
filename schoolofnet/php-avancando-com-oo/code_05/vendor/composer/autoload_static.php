<?php

// autoload_static.php @generated by Composer

namespace Composer\Autoload;

class ComposerStaticInitcbb55f0bbd240883995e287c223b47c4
{
    public static $prefixLengthsPsr4 = array (
        'S' => 
        array (
            'Source\\' => 7,
        ),
    );

    public static $prefixDirsPsr4 = array (
        'Source\\' => 
        array (
            0 => __DIR__ . '/../..' . '/src',
        ),
    );

    public static function getInitializer(ClassLoader $loader)
    {
        return \Closure::bind(function () use ($loader) {
            $loader->prefixLengthsPsr4 = ComposerStaticInitcbb55f0bbd240883995e287c223b47c4::$prefixLengthsPsr4;
            $loader->prefixDirsPsr4 = ComposerStaticInitcbb55f0bbd240883995e287c223b47c4::$prefixDirsPsr4;

        }, null, ClassLoader::class);
    }
}
