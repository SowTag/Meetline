import React, { useEffect, useState } from 'react'
import { MailIcon, PhoneOutgoingIcon } from 'lucide-react'
import { Button } from '#/components/ui/button'
import {
  Command,
  CommandDialog,
  CommandEmpty,
  CommandGroup,
  CommandInput,
  CommandItem,
  CommandList,
  CommandShortcut,
} from '#/components/ui/command'
import { Kbd } from '#/components/ui/kbd.tsx'
import { Avatar, AvatarImage } from '#/components/ui/avatar.tsx'
import { useUniversalSearch } from '#/components/universal-search/UniversalSearchProvider.tsx'

export function UniversalSearchCommandDialog() {
  const [open, setOpen] = useUniversalSearch()

  useEffect(() => {
    const down = (e: KeyboardEvent) => {
      if ((e.metaKey || e.ctrlKey) && e.key === 'k') {
        e.preventDefault()
        setOpen((prev) => !prev)
      }
    }
    window.addEventListener('keydown', down)
    return () => window.removeEventListener('keydown', down)
  }, [])

  return (
    <CommandDialog open={open} onOpenChange={setOpen}>
      <Command>
        <CommandInput placeholder="Find people, chats, and more" />
        <CommandList>
          <CommandEmpty>No results found.</CommandEmpty>
          <CommandGroup heading="People">
            {[1, 2, 3, 4, 5, 6, 7, 8, 9].map((x) => (
              <CommandItem key={x}>
                <Avatar>
                  <AvatarImage
                    src={`https://randomuser.me/api/portraits/lego/${x}.jpg`}
                  />
                </Avatar>
                Test user #{x}
                <CommandShortcut>
                  <Button variant={'ghost'}>
                    <PhoneOutgoingIcon />
                  </Button>
                  <Button variant={'ghost'}>
                    <MailIcon />
                  </Button>
                </CommandShortcut>
              </CommandItem>
            ))}
          </CommandGroup>
        </CommandList>
      </Command>
    </CommandDialog>
  )
}
